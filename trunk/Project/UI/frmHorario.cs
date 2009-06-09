using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.IO;
using HorarioMaster;

namespace HorarioMaster.UI
{
    public partial class frmHorario : DevExpress.XtraEditors.XtraForm
    {
        public frmHorario()
        {
            InitializeComponent();
        }

        #region Global Variables
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        public struct DataField
        {
            public string Hour;
            public string Day;
            public int Row;
            public int Column;
            public int Key;
            public string Group;
            public string Teacher;
            public string Subject;
            public string Shift;
            public DataField(string Data1, string Data2, string Data3, string Data4, int Data5, int Data6, int Data7, string Data8, string Data9)
            {
                Teacher = Data1;
                Subject = Data2;
                Day = Data3;
                Hour = Data4;
                Key = Data5;
                Column = Data6;
                Row = Data7;
                Group = Data8;
                Shift = Data9;
            }
        }
        private static DataField[] DRAG = new DataField[2];
        private static DataField[] DROP = new DataField[2];
        private static string SqlString = null;
        private static string[] Days = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };
        private static string[] HoursMorning = new string[] { "07:00-08:00", "08:00-09:00", "09:00-10:00", "10:00-11:00", "11:00-12:00", "12:00-13:00", "13:00-14:00" };
        private static string[] HoursEvening = new string[] { "14:00-15:00", "15:00-16:00", "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00", "20:00-21:00" };
        private static SimpleButton[][] VisualSchedule;
        private static DataField[][] DataSchedule = new DataField[][]
            {
                new DataField[5],
                new DataField[5],
                new DataField[5],
                new DataField[5],
                new DataField[5],
                new DataField[5],
                new DataField[5],
            };
        private static Color[] color = new Color[]{
            Color.AliceBlue,Color.AntiqueWhite,Color.Aqua,Color.Aquamarine,Color.Azure,
            Color.Beige,Color.Bisque,Color.BlanchedAlmond,Color.BurlyWood,Color.CadetBlue,      
            Color.Chartreuse,Color.Chocolate,Color.Coral,Color.Cornsilk,Color.Crimson,
            Color.Cyan,Color.DarkOrange,Color.DarkOrchid,Color.DarkSalmon,Color.DarkSeaGreen,
            Color.DarkTurquoise,Color.DarkViolet,Color.DeepPink,Color.DeepSkyBlue,
            Color.DodgerBlue,Color.Firebrick,Color.FloralWhite,Color.ForestGreen,Color.Fuchsia,
            Color.Gainsboro,Color.GhostWhite,Color.Gold,Color.Goldenrod,Color.Gray,Color.GreenYellow,
            Color.Honeydew,Color.HotPink,Color.IndianRed,Color.Ivory,Color.Khaki,Color.Lavender,
            Color.LavenderBlush,Color.LawnGreen,Color.LemonChiffon,Color.LightBlue,Color.LightCoral,
            Color.LightCyan,Color.LightGoldenrodYellow,Color.LightGray,Color.LightGreen,Color.LightPink,
            Color.LightSalmon,Color.LightSeaGreen,Color.LightSkyBlue,Color.LightSlateGray,Color.LightSteelBlue,
            Color.LightYellow,Color.Lime,Color.LimeGreen,Color.Linen,Color.Magenta,Color.MediumAquamarine,
            Color.MediumOrchid,Color.MediumPurple,Color.MediumSeaGreen,Color.MediumSlateBlue,Color.MediumSpringGreen,
            Color.MediumTurquoise,Color.MediumVioletRed,Color.MintCream,Color.MistyRose,Color.Moccasin,
            Color.NavajoWhite,Color.OldLace,Color.Olive,Color.OliveDrab,Color.Orange,Color.OrangeRed,Color.Orchid,
            Color.PaleGoldenrod,Color.PaleGreen,Color.PaleTurquoise,Color.PaleVioletRed,Color.PapayaWhip,Color.PeachPuff,Color.Peru,
            Color.Pink,Color.Plum,Color.PowderBlue,Color.Red,Color.RosyBrown,Color.RoyalBlue,Color.SaddleBrown,Color.Salmon,
            Color.SeaGreen,Color.SeaShell,Color.Sienna,Color.Silver,Color.SkyBlue,Color.SlateBlue,Color.SlateGray,Color.Snow,
            Color.SpringGreen,Color.SteelBlue,Color.Tan,Color.Teal,Color.Thistle,Color.Tomato,Color.Transparent,Color.Turquoise,
            Color.Violet,Color.Wheat,Color.WhiteSmoke,Color.Yellow,Color.YellowGreen
        };
        #endregion

        #region Labels Horario
        
        private void HA1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA1.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Lunes", "07:00-08:00", 0, 0); }
                else { DragDropLB("Lunes", "14:00-15:00", 0, 0); }
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(0, 0);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[0][0]; e.Effect = DragDropEffects.Link; }

        }

        private void HA1_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[0][0];
            HA1.DoDragDrop(HA1, DragDropEffects.Link);
        }

        private void HA2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA2.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                HA1.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Martes", "07:00-08:00", 0, 1); }
                else { DragDropLB("Martes", "14:00-15:00", 0, 1); }                
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(0, 1);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[0][1]; e.Effect = DragDropEffects.Link; }

        }

        private void HA2_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[0][1];
            HA2.DoDragDrop(HA2, DragDropEffects.Link);           
        }
        
        private void HA3_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA3.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Miercoles", "07:00-08:00", 0, 2); }
                else { DragDropLB("Miercoles", "14:00-15:00", 0, 2); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA3_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(0, 2);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[0][2]; e.Effect = DragDropEffects.Link; }

        }

        private void HA3_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[0][2];
            HA3.DoDragDrop(HA3, DragDropEffects.Link);
        }

        private void HA4_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA4.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Jueves", "07:00-08:00", 0, 3); }
                else { DragDropLB("Jueves", "14:00-15:00", 0, 3); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA4_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(0, 3);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[0][3]; e.Effect = DragDropEffects.Link; }

        }

        private void HA4_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[0][3];
            HA4.DoDragDrop(HA4, DragDropEffects.Link);
        }

        private void HA5_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA5.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Viernes", "07:00-08:00", 0, 4); }
                else { DragDropLB("Viernes", "14:00-15:00", 0, 4); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA5_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(0, 4);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[0][4]; e.Effect = DragDropEffects.Link; }

        }

        private void HA5_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[0][4];
            HA5.DoDragDrop(HA5, DragDropEffects.Link);
        }

        private void HA6_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA6.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Lunes", "08:00-09:00", 1, 0); }
                else { DragDropLB("Lunes", "15:00-16:00", 1, 0); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA6_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(1, 0);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[1][0]; e.Effect = DragDropEffects.Link; }

        }

        private void HA6_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[1][0];
            HA6.DoDragDrop(HA6, DragDropEffects.Link);
        }

        private void HA7_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA7.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Martes", "08:00-09:00", 1, 1); }
                else { DragDropLB("Martes", "15:00-16:00", 1, 1); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA7_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(1, 1);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[1][1]; e.Effect = DragDropEffects.Link; }

        }

        private void HA7_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[1][1];
            HA7.DoDragDrop(HA7, DragDropEffects.Link);
        }
        
        private void HA8_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA8.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Miercoles", "08:00-09:00", 1, 2); }
                else { DragDropLB("Miecoles", "15:00-16:00", 1, 2); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA8_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(1, 2);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[1][2]; e.Effect = DragDropEffects.Link; }

        }

        private void HA8_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[1][2];
            HA8.DoDragDrop(HA8, DragDropEffects.Link);
        }

        private void HA9_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA9.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Jueves", "08:00-09:00", 1, 3); }
                else { DragDropLB("Jueves", "15:00-16:00", 1, 3); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA9_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(1, 3);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[1][3]; e.Effect = DragDropEffects.Link; }

        }

        private void HA9_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[1][3];
            HA9.DoDragDrop(HA9, DragDropEffects.Link);
        }

        private void HA10_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA10.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Viernes", "08:00-09:00", 1, 4); }
                else { DragDropLB("Viernes", "15:00-16:00", 1, 4); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA10_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(1, 4);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[1][4]; e.Effect = DragDropEffects.Link; }

        }

        private void HA10_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[1][4];
            HA10.DoDragDrop(HA10, DragDropEffects.Link);
        }

        private void HA11_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA11.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Lunes", "09:00-10:00", 2, 0); }
                else { DragDropLB("Lunes", "16:00-17:00", 2, 0); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA11_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(2, 0);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[2][0]; e.Effect = DragDropEffects.Link; }

        }

        private void HA11_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[2][0];
            HA11.DoDragDrop(HA11, DragDropEffects.Link);
        }

        private void HA12_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA12.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Martes", "09:00-10:00", 2, 1); }
                else { DragDropLB("Martes", "16:00-17:00", 2, 1); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA12_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(2, 1);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[2][1]; e.Effect = DragDropEffects.Link; }

        }

        private void HA12_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[2][1];
            HA12.DoDragDrop(HA12, DragDropEffects.Link);
        }

        private void HA13_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA13.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Miercoles", "09:00-10:00", 2, 2); }
                else { DragDropLB("Miercoles", "16:00-17:00", 2, 2); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA13_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(2, 2);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[2][2]; e.Effect = DragDropEffects.Link; }

        }

        private void HA13_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[2][2];
            HA13.DoDragDrop(HA13, DragDropEffects.Link);
        }

        private void HA14_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA14.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Jueves", "09:00-10:00", 2, 3); }
                else { DragDropLB("Jueves", "16:00-17:00", 2, 3); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA14_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(2, 3);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[2][3]; e.Effect = DragDropEffects.Link; }

        }

        private void HA14_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[2][3];
            HA14.DoDragDrop(HA14, DragDropEffects.Link);
        }

        private void HA15_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA15.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Viernes", "09:00-10:00", 2, 4); }
                else { DragDropLB("Viernes", "16:00-17:00", 2, 4); }
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA15_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(2, 4);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[2][4]; e.Effect = DragDropEffects.Link; }

        }

        private void HA15_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[2][4];
            HA15.DoDragDrop(HA15, DragDropEffects.Link);
        }

        private void HA16_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA16.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Lunes", "10:00:11:00", 3, 0); }
                else { DragDropLB("Lunes", "17:00-18:00", 3, 0); }  
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA16_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(3, 0);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[3][0]; e.Effect = DragDropEffects.Link; }

        }

        private void HA16_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[3][0];
            HA16.DoDragDrop(HA16, DragDropEffects.Link);
        }

        private void HA17_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA17.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Martes", "10:00:11:00", 3, 1); }
                else { DragDropLB("Martes", "17:00-18:00", 3, 1); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA17_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(3, 1);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[3][1]; e.Effect = DragDropEffects.Link; }

        }

        private void HA17_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[3][1];
            HA17.DoDragDrop(HA17, DragDropEffects.Link);
        }
        
        private void HA18_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA18.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Miercoles", "10:00:11:00", 3, 2); }
                else { DragDropLB("Miercoles", "17:00-18:00", 3, 2); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA18_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(3, 2);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[3][2]; e.Effect = DragDropEffects.Link; }

        }

        private void HA18_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[3][2];
            HA18.DoDragDrop(HA18, DragDropEffects.Link);
        }

        private void HA19_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA19.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Jueves", "10:00:11:00", 3, 3); }
                else { DragDropLB("Jueves", "17:00-18:00", 3, 3); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA19_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(3, 3);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[3][3]; e.Effect = DragDropEffects.Link; }

        }

        private void HA19_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[3][3];
            HA19.DoDragDrop(HA19, DragDropEffects.Link);
        }

        private void HA20_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA20.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Viernes", "10:00:11:00", 3, 4); }
                else { DragDropLB("Viernes", "17:00-18:00", 3, 4); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA20_DragEnter(object sender, DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(3, 4);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[3][4]; e.Effect = DragDropEffects.Link; }
        }
       
        private void HA20_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[3][4];
            HA20.DoDragDrop(HA20, DragDropEffects.Link);
        }

        private void HA21_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA21.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Lunes", "11:00:12:00", 4, 0); }
                else { DragDropLB("Lunes", "18:00-19:00", 4, 0); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA21_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(4, 0);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[4][0]; e.Effect = DragDropEffects.Link; }

        }

        private void HA21_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[4][0];
            HA21.DoDragDrop(HA21, DragDropEffects.Link);
        }

        private void HA22_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA22.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Martes", "11:00:12:00", 4, 1); }
                else { DragDropLB("Martes", "18:00-19:00", 4, 1); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA22_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(4, 1);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[4][1]; e.Effect = DragDropEffects.Link; }

        }

        private void HA22_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[4][1];
            HA22.DoDragDrop(HA22, DragDropEffects.Link);
        }
        
        private void HA23_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA23.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Miercoles", "11:00:12:00", 4, 2); }
                else { DragDropLB("Miercoles", "18:00-19:00", 4, 2); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA23_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(4, 2);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[4][2]; e.Effect = DragDropEffects.Link; }

        }

        private void HA23_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[4][2];
            HA23.DoDragDrop(HA23, DragDropEffects.Link);
        }

        private void HA24_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA24.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Jueves", "11:00:12:00", 4, 3); }
                else { DragDropLB("Jueves", "18:00-19:00", 4, 3); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA24_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(4, 3);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[4][3]; e.Effect = DragDropEffects.Link; }

        }

        private void HA24_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[4][3];
            HA24.DoDragDrop(HA24, DragDropEffects.Link);
        }

        private void HA25_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA25.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Viernes", "11:00:12:00", 4, 4); }
                else { DragDropLB("Viernes", "18:00-19:00", 4, 4); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA25_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(4, 4);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[4][4]; e.Effect = DragDropEffects.Link; }

        }

        private void HA25_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[4][4];
            HA25.DoDragDrop(HA25, DragDropEffects.Link);
        }

        private void HA26_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA26.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Lunes", "12:00:13:00", 5, 0); }
                else { DragDropLB("Lunes", "19:00-20:00", 5, 0); }                 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA26_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(5, 0);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[5][0]; e.Effect = DragDropEffects.Link; }

        }

        private void HA26_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[5][0];
            HA26.DoDragDrop(HA26, DragDropEffects.Link);
        }

        private void HA27_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA27.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Martes", "12:00:13:00", 5, 1); }
                else { DragDropLB("Martes", "19:00-20:00", 5, 1); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA27_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(5, 1);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[5][1]; e.Effect = DragDropEffects.Link; }

        }

        private void HA27_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[5][1];
            HA27.DoDragDrop(HA27, DragDropEffects.Link);
        }
        
        private void HA28_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA28.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Miercoles", "12:00:13:00", 5, 2); }
                else { DragDropLB("Miercoles", "19:00-20:00", 5, 2); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA28_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(5, 2);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[5][2]; e.Effect = DragDropEffects.Link; }

        }

        private void HA28_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[5][2];
            HA28.DoDragDrop(HA28, DragDropEffects.Link);
        }

        private void HA29_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA29.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Jueves", "12:00:13:00", 5, 3); }
                else { DragDropLB("Jueves", "19:00-20:00", 5, 3); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA29_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(5, 3);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[5][3]; e.Effect = DragDropEffects.Link; }

        }

        private void HA29_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[5][3];
            HA29.DoDragDrop(HA29, DragDropEffects.Link);
        }

        private void HA30_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA30.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Viernes", "12:00:13:00", 5, 4); }
                else { DragDropLB("Viernes", "19:00-20:00", 5, 4); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA30_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(5, 4);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[5][4]; e.Effect = DragDropEffects.Link; }

        }

        private void HA30_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[5][4];
            HA30.DoDragDrop(HA30, DragDropEffects.Link);
        }

        private void HA31_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA31.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Lunes", "13:00:14:00", 6, 0); }
                else { DragDropLB("Lunes", "20:00-21:00", 6, 0); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA31_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(6, 0);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[6][0]; e.Effect = DragDropEffects.Link; }

        }

        private void HA31_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[6][0];
            HA31.DoDragDrop(HA31, DragDropEffects.Link);
        }

        private void HA32_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA32.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Martes", "13:00:14:00", 6, 1); }
                else { DragDropLB("Martes", "20:00-21:00", 6, 1); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA32_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(6, 1);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[6][1]; e.Effect = DragDropEffects.Link; }

        }

        private void HA32_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[6][1];
            HA32.DoDragDrop(HA32, DragDropEffects.Link);
        }
        
        private void HA33_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA33.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Miercoles", "13:00:14:00", 6, 2); }
                else { DragDropLB("Miercoles", "20:00-21:00", 6, 2); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA33_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(6, 2);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[6][2]; e.Effect = DragDropEffects.Link; }

        }

        private void HA33_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[6][2];
            HA33.DoDragDrop(HA33, DragDropEffects.Link);
        }

        private void HA34_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA34.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Jueves", "13:00:14:00", 6, 3); }
                else { DragDropLB("Jueves", "20:00-21:00", 6, 3); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA34_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(6, 3);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[6][3]; e.Effect = DragDropEffects.Link; }

        }

        private void HA34_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[6][3];
            HA34.DoDragDrop(HA34, DragDropEffects.Link);
        }

        private void HA35_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (lbComplementaryActivities.SelectedItem != null)
            {
                HA35.Text = JustifyString(lbComplementaryActivities.SelectedItem.ToString());
                if (cmbShift.Text == "MATUTINO")
                { DragDropLB("Viernes", "13:00:14:00", 6, 4); }
                else { DragDropLB("Viernes", "20:00-21:00", 6, 4); } 
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                DROP[1] = DROP[0];
                DRAG[1] = DRAG[0];
                FillDragDrop();
                ChangeFields();
                FillSchedules();
                e.Effect = DragDropEffects.Move;
            }
        }

        private void HA35_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cmbScheduleType.Text == "Maestro")
            {
                DragEnterTeacher(6, 4);
                e.Effect = DragDropEffects.Link;
            }
            else { DROP[0] = DataSchedule[6][4]; e.Effect = DragDropEffects.Link; }

        }

        private void HA35_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[6][4];
            HA35.DoDragDrop(HA35, DragDropEffects.Link);
        }

        #endregion

        # region Controls events        

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicilazeDatachedule();
            if (cmbScheduleType.Text == "Grupo")
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                lEspecialidad.Text = DataBaseUtilities.ReturnRecord("Select Especialidad From Grupos Where SG ='" + cmbGroups.Text + "'", "Especialidad").ToString();
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                lTurno.Text = DataBaseUtilities.ReturnRecord("Select Turno From Grupos Where SG ='" + cmbGroups.Text + "'", "Turno").ToString();
                DataBaseUtilities.CloseConnection();

            }
            else
            {
                HEspecialidad.Text = "NUMERO DE TARJETA:";
                DataBaseUtilities.OpenConnection(PathDataBase);
                lEspecialidad.Text = DataBaseUtilities.ReturnRecord("Select NumeroTarjeta From Personal Where Nombre ='" + cmbGroups.Text + "'", "NumeroTarjeta").ToString();
                DataBaseUtilities.CloseConnection();
                HTurno.Text = "PERFIL:";
                DataBaseUtilities.OpenConnection(PathDataBase);
                lTurno.Text = DataBaseUtilities.ReturnRecord("Select Perfil From Personal Where Nombre ='" + cmbGroups.Text + "'", "Perfil").ToString();
                DataBaseUtilities.CloseConnection();
            }
            FilllbSchedule();
            FillSchedules();
            AssignColor();
        }

        private void cmbScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGroups.Properties.Items.Clear();
            cmbGroups.Text = "";
            if (cmbScheduleType.Text == "Grupo")
            {
                groupBoxDatos.Text = "Informacion de Grupo";
                cmbShift.Visible = false;
                cmbGroups.Width = 57;
                DataBaseUtilities.OpenConnection(PathDataBase);
                cmbGroups = DataBaseUtilities.FillComboBoxEdit("Select Grupo From MaestroMateria", "Grupo", cmbGroups);
                DataBaseUtilities.CloseConnection();
                cmbGroups.Text = cmbGroups.Properties.Items[0].ToString();
                HEspecialidad.Text = "ESPECIALIDAD:";
                HTurno.Text = "TURNO:";
                DataBaseUtilities.OpenConnection(PathDataBase);
                lTurno.Text = DataBaseUtilities.ReturnRecord("Select Turno From Grupos Where SG ='" + cmbGroups.Text + "'", "Turno").ToString();
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                lEspecialidad.Text = DataBaseUtilities.ReturnRecord("Select Especialidad From Grupos Where SG ='" + cmbGroups.Text + "'", "Especialidad").ToString();
                DataBaseUtilities.CloseConnection();
                LimpiarHorario.Visible = true;
                lTurno.Visible = true;
                lbComplementaryActivities.Visible = false;
                button1.Visible = true;               
                LimpiarHorario.Visible = true;
                FilllbSchedule();
                AssignColor();
            }
            else
            {
                groupBoxDatos.Text = "Informacion de Maestro";
                cmbShift.Visible = true;
                cmbGroups.Width = 268;
                DataBaseUtilities.OpenConnection(PathDataBase);
                cmbGroups = DataBaseUtilities.FillComboBoxEdit("Select Nombre From Personal WHERE Actividad='DOCENTE'", "Nombre", cmbGroups);
                DataBaseUtilities.CloseConnection();
                if (cmbGroups.Properties.Items.Count == 0)
                {
                    MessageBox.Show("En este momento no existen Horarios!!");                    
                }
                else
                {
                    cmbGroups.Text = cmbGroups.Properties.Items[0].ToString();
                    HEspecialidad.Text = "NUMERO DE TARJETA:";
                    DataBaseUtilities.OpenConnection(PathDataBase);
                    lEspecialidad.Text = DataBaseUtilities.ReturnRecord("Select NumeroTarjeta From Personal Where Nombre ='" + cmbGroups.Text + "'", "NumeroTarjeta").ToString();
                    DataBaseUtilities.CloseConnection();
                    HTurno.Text = "PERFIL:";
                    DataBaseUtilities.OpenConnection(PathDataBase);
                    lTurno.Text = DataBaseUtilities.ReturnRecord("Select Perfil From Personal Where Nombre ='" + cmbGroups.Text + "'", "Perfil").ToString();
                    DataBaseUtilities.CloseConnection();
                    button1.Visible = false;                    
                    LimpiarHorario.Visible = false;
                    lbComplementaryActivities.Visible = true;
                    FillComplementaryActivities();
                    FilllbSchedule();
                    //AssignColor();
                }
            }
        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicilazeDatachedule();
            FilllbSchedule();
            FillSchedules();
            AssignColor();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GenerateSchedule();            
            int nScheduleComplete = 0;
            int nHour = 0;
            string sShift = GetShiftGroup();
            List<DataField> DataFieldTempList = new List<DataField>();
            DataField DataFieldtemp = new DataField();
            DataBaseUtilities.OpenConnection(PathDataBase);
            SqlString = @"SELECT MaestroMateria.Maestro, MaestroMateria.Grupo, MaestroMateria.Materia, Materias.HC
                          FROM Materias INNER JOIN MaestroMateria ON Materias.Clave = MaestroMateria.Clave
                          WHERE (((MaestroMateria.Grupo)='" + cmbGroups.Text + "'));";

            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
            while (dr.Read())
            {
                if (!DataBaseUtilities.RecordExist("Select Materia From HorarioMaterias Where Materia='" + dr["Materia"].ToString() + "' AND Grupo='" + cmbGroups.Text + "'"))
                {
                    DataFieldtemp.Teacher = dr["Maestro"].ToString();
                    DataFieldtemp.Subject = dr["Materia"].ToString();
                    DataFieldtemp.Hour = dr["HC"].ToString();
                    DataFieldtemp.Group = cmbGroups.Text;
                    DataFieldTempList.Add(DataFieldtemp);
                }
            }
            DataBaseUtilities.CloseConnection();
            foreach (DataField DataFieldTemp in DataFieldTempList)
            {
                nHour = Convert.ToInt32(DataFieldTemp.Hour);
                while (nHour > 0)
                {
                    nHour = nHour - 1;
                    for (int nRow = 0; nRow < 7; nRow++)
                    {
                        for (int nColumn = 0; nColumn < 5; nColumn++)
                        {
                            DataBaseUtilities.OpenConnection(PathDataBase);
                            //                            SqlString = "Select Materia From HorarioMaterias Where Grupo='" + cmbGroups.Text + "' And PosicionFila="+nRow+@"
                            //                                         And PosicionColumna="+nColumn+"";
//                            SqlString = @"SELECT HorarioMaterias.Materia FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
//                                          WHERE (((HorarioMaterias.Dia)='" + DataSchedule[nRow][nColumn].Day + "') AND ((HorarioMaterias.Hora)='" + DataSchedule[nRow][nColumn].Hour + "') AND ((MaestroMateria.Maestro)='" + DataFieldTemp.Teacher + @"') OR 
//                                          ((HorarioMaterias.Dia)='" + DataSchedule[nRow][nColumn].Day + "') AND ((HorarioMaterias.Hora)='" + DataSchedule[nRow][nColumn].Hour + "') AND ((MaestroMateria.Grupo)='" + cmbGroups.Text + "'))";
                            SqlString = @"SELECT HorarioMaterias.[Grupo], HorarioMaterias.[Dia], HorarioMaterias.[Hora], HorarioMaterias.[Maestro]
                                          FROM HorarioMaterias WHERE (((HorarioMaterias.[Dia])='"+DataSchedule[nRow][nColumn].Day+"') AND ((HorarioMaterias.[Hora])='"+DataSchedule[nRow][nColumn].Hour+"') AND ((HorarioMaterias.[Maestro])='"+DataFieldTemp.Teacher+@"')) 
                                          OR (((HorarioMaterias.[Grupo])='"+cmbGroups.Text+"') AND ((HorarioMaterias.[Dia])='"+DataSchedule[nRow][nColumn].Day+"') AND ((HorarioMaterias.[Hora])='"+DataSchedule[nRow][nColumn].Hour+"'))";
                            if (!DataBaseUtilities.RecordExist(SqlString))
                            {
                                SqlString = "INSERT INTO HorarioMaterias (Materia,Hora,Dia,Grupo,PosicionFila,PosicionColumna,Turno,Maestro) Values('" + DataFieldTemp.Subject + "','" + DataSchedule[nRow][nColumn].Hour +
                                            "','" + DataSchedule[nRow][nColumn].Day + "','" + cmbGroups.Text + "'," + nRow + "," + nColumn + ",'" + sShift + "','" + DataFieldTemp.Teacher + "')"; ;
                                DataBaseUtilities.ExecuteNonSql(SqlString);
                                VisualSchedule[nRow][nColumn].Text = DataFieldTemp.Subject;
                                nRow = 7;
                                nColumn = 5;
                            }
                            DataBaseUtilities.CloseConnection();
                            nScheduleComplete++;
                        }
                        if (nScheduleComplete > 34)
                        { MessageBox.Show("Horario Completo algunas horas no se pudieron agregar"); return; }
                    }
                    nScheduleComplete = 0;
                }
            }
        }

        private void LimpiarHorario_Click(object sender, EventArgs e)
        {
            ClearSchedules();
            SqlString = "Delete From HorarioMaterias Where Grupo='" + cmbGroups.Text + "'";
            DataBaseUtilities.OpenConnection(PathDataBase);
            DataBaseUtilities.ExecuteNonSql(SqlString);
            DataBaseUtilities.CloseConnection();
        }

        private void lbComplementaryActivities_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lbComplementaryActivities_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void lbComplementaryActivities_MouseDown(object sender, MouseEventArgs e)
        {
            lbComplementaryActivities.DoDragDrop(lbComplementaryActivities, DragDropEffects.Link);
        }

        private void cmbShift_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            InicilazeDatachedule();
            FilllbSchedule();
            FillSchedules();
            AssignColor();
        }
 
        # endregion

        # region Functions

        private void InicilazeDatachedule()
        {
            if (cmbScheduleType.Text == "Grupo")
            {
                string sShift = GetShiftGroup();
                for (int Row = 0; Row < 7; Row++)
                {
                    for (int Column = 0; Column < 5; Column++)
                    {
                        DataSchedule[Row][Column].Row = Row;
                        DataSchedule[Row][Column].Column = Column;
                        DataSchedule[Row][Column].Day = Days[Column];
                        DataSchedule[Row][Column].Shift = sShift;
                        if (sShift == "MATUTINO")
                        { DataSchedule[Row][Column].Hour = HoursMorning[Row]; }
                        else
                        { DataSchedule[Row][Column].Hour = HoursEvening[Row]; }
                    }
                }
            }
            else
            {
                for (int Row = 0; Row < 7; Row++)
                {
                    for (int Column = 0; Column < 5; Column++)
                    {
                        DataSchedule[Row][Column].Row = Row;
                        DataSchedule[Row][Column].Column = Column;
                        DataSchedule[Row][Column].Day = Days[Column];
                        DataSchedule[Row][Column].Shift = cmbShift.Text;
                        if (cmbShift.Text == "MATUTINO")
                        { DataSchedule[Row][Column].Hour = HoursMorning[Row]; }
                        else
                        { DataSchedule[Row][Column].Hour = HoursEvening[Row]; }
                    }
                }
            }
        }

        private void FilllbSchedule()
        {
            int nItems = 1;
            string sShift = null;
            lbSchedule.Items.Clear();
            if (cmbScheduleType.Text == "Grupo")
            { sShift = GetShiftGroup(); }
            else { sShift = cmbShift.Text; }
            if (sShift == "MATUTINO")
            {
                foreach (string Hour in HoursMorning)
                {
                    if (nItems == 1 || nItems == 3 || nItems == 5)
                    {                        
                        lbSchedule.Items.Add(Hour);
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                    }
                    else if (nItems == 2 || nItems == 4 || nItems == 6)
                    {
                        lbSchedule.Items.Add(Hour); 
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                    }
                    else if (nItems == 7)
                    {
                        lbSchedule.Items.Add(Hour);                        
                    }
                    nItems++;
                }
            }
            else
            {
                foreach (string Hour in HoursEvening)
                {
                    if (nItems == 1 || nItems == 3 || nItems == 5)
                    {
                        lbSchedule.Items.Add(Hour);
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                    }
                    else if (nItems == 2 || nItems == 4 || nItems == 6)
                    {
                        lbSchedule.Items.Add(Hour);
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                        lbSchedule.Items.Add("");
                    }
                    else if (nItems == 7)
                    {
                        lbSchedule.Items.Add(Hour);
                    }
                    nItems++;
                }
            }
        }

        private string GetShiftGroup()
        {
            string sShift = null;
            SqlString = "Select Turno From Grupos Where SG='" + cmbGroups.Text + "'";
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = HorarioMaster.DataBaseUtilities.ExecuteSql(SqlString);
            dr.Read();
            sShift = dr["Turno"].ToString();
            DataBaseUtilities.CloseConnection();
            return sShift;
        }

        private void FillSchedules()
        {
            ClearSchedules();
            if (cmbScheduleType.Text == "Grupo")
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                SqlString = @"SELECT HorarioMaterias.Materia, HorarioMaterias.PosicionColumna,HorarioMaterias.PosicionFila, HorarioMaterias.ClaveHM, MaestroMateria.Maestro
                              FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                              WHERE (((HorarioMaterias.Grupo)='" + cmbGroups.Text + "'))";
                OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
                while (dr.Read())
                {
                    VisualSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Text = JustifyString(dr["Materia"].ToString());//dr["Materia"].ToString();
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Group = cmbGroups.Text;
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Key = Convert.ToInt32(dr["ClaveHM"]);
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Teacher = dr["Maestro"].ToString();
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Subject = dr["Materia"].ToString();
                }
                DataBaseUtilities.CloseConnection();
            }
            else
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                SqlString = @"SELECT ClaveHM, Materia, PosicionColumna, PosicionFila,Grupo,Maestro
                            FROM HorarioMaterias
                            WHERE (((HorarioMaterias.Maestro)='" + cmbGroups.Text + "') AND ((HorarioMaterias.Turno)='" + cmbShift.Text + "'))";

                OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
                while (dr.Read())
                {
                    VisualSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Text = JustifyString(dr["Materia"].ToString());//dr["Materia"].ToString();
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Group = dr["Grupo"].ToString();
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Key = Convert.ToInt32(dr["ClaveHM"]);
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Teacher = dr["Maestro"].ToString();
                    DataSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Subject = dr["Materia"].ToString();
                }
                DataBaseUtilities.CloseConnection();
            }
        }

        private void ClearSchedules()
        {
            for (int Fila = 0; Fila < 7; Fila++)
            {
                for (int Columna = 0; Columna < 5; Columna++)
                {
                    VisualSchedule[Fila][Columna].Text = "";
                    DataSchedule[Fila][Columna].Key = -1;
                    DataSchedule[Fila][Columna].Subject = "";
                    DataSchedule[Fila][Columna].Teacher = "";
                    DataSchedule[Fila][Columna].Group = "";
                }
            }
        }

        private void GenerateSchedule()
        {

        }

        private DataField FindBlankSpace(DataField Temporal)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            if (cmbScheduleType.Text == "Grupo")
            { SqlString = "Select * From HorarioMaterias Where Maestro='" + Temporal.Teacher + "'"; }
            else { SqlString = "Select * From HorarioMaterias Where Grupo='" + Temporal.Group + "'"; }
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
            List<DataField> ListTeacher = new List<DataField>(); ;
            DataField x = new DataField();
            while (dr.Read())
            {
                x.Column = Convert.ToInt32(dr["PosicionColumna"]);
                x.Row = Convert.ToInt32(dr["PosicionFila"]);
                ListTeacher.Add(x);
            }
            DataBaseUtilities.CloseConnection();
            int ban = 0;
            for (int nRow = 0; nRow < 7; nRow++)
            {
                for (int nColumn = 0; nColumn < 5; nColumn++)
                {
                    foreach (DataField y in ListTeacher)
                    {
                        if (y.Row == nRow && y.Column == nColumn)
                        {
                            ban = 1;
                            break;
                        }
                    }
                    DataBaseUtilities.OpenConnection(PathDataBase);
                    if (ban == 0 && !DataBaseUtilities.RecordExist("Select Materia From HorarioMaterias Where PosicionFila=" + nRow + " AND PosicionColumna=" + nColumn + " AND Grupo='" + Temporal.Group + "'"))
                    {
                        Temporal.Column = nColumn;
                        Temporal.Row = nRow;
                        return Temporal;
                    }
                    DataBaseUtilities.CloseConnection();
                    ban = 0;
                }
            }
            MessageBox.Show("No hay Horas Disponibles");
            return Temporal;
        }

        private void FillDragDrop()
        {
            SqlString = @"Select ClaveHM,Materia,Grupo 
                          From HorarioMaterias 
                          Where Dia='" + DROP[0].Day + "' AND Hora='" + DROP[0].Hour + "' AND Maestro='" + DRAG[0].Teacher + "' AND Grupo<>'" + DRAG[0].Group + "'";
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
            if (dr.Read())
            {
                DROP[1].Key = Convert.ToInt32(dr["ClaveHM"]);
                DROP[1].Subject = dr["Materia"].ToString();
                DROP[1].Group = dr["Grupo"].ToString();
                DROP[1].Teacher = DRAG[0].Teacher;
            }
            else { DROP[1] = new DataField(null, null, null, null, -1, -1, -1, null, null); }
            DataBaseUtilities.CloseConnection();
            SqlString = @"Select ClaveHM,Materia,Grupo 
                          From HorarioMaterias 
                          Where Dia='" + DRAG[0].Day + "' AND Hora='" + DRAG[0].Hour + "' AND Maestro='" + DROP[0].Teacher + "' AND Grupo<>'" + DROP[0].Group + "'";
            DataBaseUtilities.OpenConnection(PathDataBase);
            dr = DataBaseUtilities.ExecuteSql(SqlString);
            if (dr.Read())
            {
                DRAG[1].Key = Convert.ToInt32(dr["ClaveHM"]);
                DRAG[1].Subject = dr["Materia"].ToString();
                DRAG[1].Group = dr["Grupo"].ToString();
                DRAG[1].Teacher = DROP[0].Teacher;
            }
            else
            { DRAG[1] = new DataField(null, null, null, null, -1, -1, -1, null, null); }
            DataBaseUtilities.CloseConnection();
        }

        private void ChangeFields()
        {
            DataField Temp = new DataField();
            Color cTemp = new Color();
            if (DRAG[0].Teacher == DROP[1].Teacher && DRAG[1].Teacher == DROP[0].Teacher && DRAG[1].Group == DROP[1].Group)
            {
                int Key0 = DRAG[0].Key, Key1 = DROP[0].Key, Key2 = DRAG[1].Key, Key3 = DROP[1].Key;
                Temp = DRAG[0];
                cTemp = VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor;
                VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor = VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor;
                DRAG[0] = DROP[0];
                VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor = cTemp;
                DROP[0] = Temp;
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DRAG[0].Hour + "',Dia='" + DRAG[0].Day + "',PosicionFila=" + DRAG[0].Row + ",PosicionColumna=" + DRAG[0].Column + " Where ClaveHM=" + Key0 + "";
                DataBaseUtilities.OpenConnection(PathDataBase);
                DataBaseUtilities.ExecuteNonSql(SqlString);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DROP[0].Hour + "',Dia='" + DROP[0].Day + "',PosicionFila=" + DROP[0].Row + ",PosicionColumna=" + DROP[0].Column + " Where ClaveHM=" + Key1 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DROP[1].Hour + "',Dia='" + DROP[1].Day + "',PosicionFila=" + DROP[1].Row + ",PosicionColumna=" + DROP[1].Column + " Where ClaveHM=" + Key2 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DRAG[1].Hour + "',Dia='" + DRAG[1].Day + "',PosicionFila=" + DRAG[1].Row + ",PosicionColumna=" + DRAG[1].Column + " Where ClaveHM=" + Key3 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
            }
            //Si DRAG[1] y DROP[1] no son iguales a los maestro que vas a mover
            //En duda
            else if (DRAG[1].Teacher != null && DROP[1].Teacher != null)
            {
                int Key0 = DRAG[0].Key, Key1 = DROP[0].Key, Key2 = DRAG[1].Key, Key3 = DROP[1].Key;
                Temp = DRAG[0];
                cTemp = VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor;
                VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor = VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor;
                DRAG[0] = DROP[0];
                VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor = cTemp;
                DROP[0] = Temp;
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DRAG[0].Hour + "',Dia='" + DRAG[0].Day + "',PosicionFila=" + DRAG[0].Row + ",PosicionColumna=" + DRAG[0].Column + " Where ClaveHM=" + Key0 + "";
                DataBaseUtilities.OpenConnection(PathDataBase);
                DataBaseUtilities.ExecuteNonSql(SqlString);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DROP[0].Hour + "',Dia='" + DROP[0].Day + "',PosicionFila=" + DROP[0].Row + ",PosicionColumna=" + DROP[0].Column + " Where ClaveHM=" + Key1 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                DROP[1] = FindBlankSpace(DROP[1]);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DataSchedule[DROP[1].Row][DROP[1].Column].Hour + "',Dia='" + DataSchedule[DROP[1].Row][DROP[1].Column].Day + "',PosicionFila=" + DROP[1].Row + ",PosicionColumna=" + DROP[1].Column + " Where ClaveHM=" + Key2 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                DRAG[1] = FindBlankSpace(DRAG[1]);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DataSchedule[DRAG[1].Row][DRAG[1].Column].Hour + "',Dia='" + DataSchedule[DRAG[1].Row][DRAG[1].Column].Day + "',PosicionFila=" + DRAG[1].Row + ",PosicionColumna=" + DRAG[1].Column + " Where ClaveHM=" + Key3 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
            }
            //Si no hay maestros en otros horarios en los campos que se van a cambiar  
            else if (DRAG[1].Teacher == null && DROP[1].Teacher == null)
            {
                int Key0 = DRAG[0].Key, Key1 = DROP[0].Key;
                Temp = DRAG[0];
                cTemp = VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor;
                VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor = VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor;
                DRAG[0] = DROP[0];
                VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor = cTemp;
                DROP[0] = Temp;
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DRAG[0].Hour + "',Dia='" + DRAG[0].Day + "',PosicionFila=" + DRAG[0].Row + ",PosicionColumna=" + DRAG[0].Column + " Where ClaveHM=" + Key0 + "";
                DataBaseUtilities.OpenConnection(PathDataBase);
                DataBaseUtilities.ExecuteNonSql(SqlString);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DROP[0].Hour + "',Dia='" + DROP[0].Day + "',PosicionFila=" + DROP[0].Row + ",PosicionColumna=" + DROP[0].Column + " Where ClaveHM=" + Key1 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
            }
            //Si solo el DRAG[1] no tiene maestro = en otro lado
            else if (DRAG[1].Teacher == null)
            {
                int Key0 = DRAG[0].Key, Key1 = DROP[0].Key, Key2 = DROP[1].Key;
                Temp = DRAG[0];
                cTemp = VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor;
                VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor = VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor;
                DRAG[0] = DROP[0];
                VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor = cTemp;
                DROP[0] = Temp;
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DRAG[0].Hour + "',Dia='" + DRAG[0].Day + "',PosicionFila=" + DRAG[0].Row + ",PosicionColumna=" + DRAG[0].Column + " Where ClaveHM=" + Key0 + "";
                DataBaseUtilities.OpenConnection(PathDataBase);
                DataBaseUtilities.ExecuteNonSql(SqlString);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DROP[0].Hour + "',Dia='" + DROP[0].Day + "',PosicionFila=" + DROP[0].Row + ",PosicionColumna=" + DROP[0].Column + " Where ClaveHM=" + Key1 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
                DROP[1] = FindBlankSpace(DROP[1]);
                DataBaseUtilities.OpenConnection(PathDataBase);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DataSchedule[DROP[1].Row][DROP[1].Column].Hour + "',Dia='" + DataSchedule[DROP[1].Row][DROP[1].Column].Day + "',PosicionFila=" + DROP[1].Row + ",PosicionColumna=" + DROP[1].Column + " Where ClaveHM=" + Key2 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
            }
            //Si solo el DROP[1] no tiene maestro = en otro lado
            else if (DROP[1].Teacher == null)
            {
                int Key0 = DRAG[0].Key, Key1 = DROP[0].Key, Key2 = DRAG[1].Key;
                Temp = DRAG[0];
                cTemp = VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor;
                VisualSchedule[DRAG[0].Row][DRAG[0].Column].BackColor = VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor;
                DRAG[0] = DROP[0];
                VisualSchedule[DROP[0].Row][DROP[0].Column].BackColor = cTemp;
                DROP[0] = Temp;
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DRAG[0].Hour + "',Dia='" + DRAG[0].Day + "',PosicionFila=" + DRAG[0].Row + ",PosicionColumna=" + DRAG[0].Column + " Where ClaveHM=" + Key0 + "";
                DataBaseUtilities.OpenConnection(PathDataBase);
                DataBaseUtilities.ExecuteNonSql(SqlString);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DROP[0].Hour + "',Dia='" + DROP[0].Day + "',PosicionFila=" + DROP[0].Row + ",PosicionColumna=" + DROP[0].Column + " Where ClaveHM=" + Key1 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
                DRAG[1] = FindBlankSpace(DRAG[1]);
                DataBaseUtilities.OpenConnection(PathDataBase);
                SqlString = "UPDATE HorarioMaterias SET Hora='" + DataSchedule[DRAG[1].Row][DRAG[1].Column].Hour + "',Dia='" + DataSchedule[DRAG[1].Row][DRAG[1].Column].Day + "',PosicionFila=" + DRAG[1].Row + ",PosicionColumna=" + DRAG[1].Column + " Where ClaveHM=" + Key2 + "";
                DataBaseUtilities.ExecuteNonSql(SqlString);
                DataBaseUtilities.CloseConnection();
            }
        }

        private void AssignColor()
        {
            for (int nRow = 0; nRow < 7; nRow++)
            {
                for (int nColumn = 0; nColumn < 5; nColumn++)
                {
                    VisualSchedule[nRow][nColumn].BackColor = Color.White;
                }
            }
            List<int> UsedColor = new List<int>();
            List<string> UsedSubject = new List<string>();
            Random ColorRandom = new Random();
            bool ColorExist = true;
            int nColor = new int();
            int nSubject = new int();
            if (cmbScheduleType.Text == "Grupo")
            {
                SqlString = @"SELECT First(HorarioMaterias.Materia) AS MateriaCampo, Count(HorarioMaterias.Materia) AS NúmeroDeDuplicados
                        FROM HorarioMaterias GROUP BY HorarioMaterias.Materia, HorarioMaterias.Grupo HAVING (((Count(HorarioMaterias.Materia))>=1) 
                        AND ((HorarioMaterias.Grupo)='" + cmbGroups.Text + "'))";
            }
            else
            {
               SqlString = @"SELECT First(HorarioMaterias.Materia) AS MateriaCampo, Count(HorarioMaterias.Materia) AS NúmeroDeDuplicados, HorarioMaterias.Turno, HorarioMaterias.Maestro
                            FROM HorarioMaterias
                            GROUP BY HorarioMaterias.Materia, HorarioMaterias.Turno, HorarioMaterias.Maestro
                            HAVING (((Count(HorarioMaterias.Materia))>=1) AND ((HorarioMaterias.Turno)='" + cmbShift.Text + "') AND ((HorarioMaterias.Maestro)='" + cmbGroups.Text + "'))";

            }
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
            while (dr.Read())
            {
                while (ColorExist)
                {
                    nColor = ColorRandom.Next(115);
                    if (UsedColor.BinarySearch(nColor) < 0)
                    {
                        UsedColor.Add(nColor);
                        UsedSubject.Add(dr["MateriaCampo"].ToString());
                        ColorExist = false;
                    }
                }
                ColorExist = true;
            }
            DataBaseUtilities.CloseConnection();
            for (int nRow = 0; nRow < 7; nRow++)
            {
                for (int nColumn = 0; nColumn < 5; nColumn++)
                {
                    if (VisualSchedule[nRow][nColumn].Text != "")
                    {
                        nSubject = UsedSubject.BinarySearch(VisualSchedule[nRow][nColumn].Text);
                    }
                }
            }
        }

        private void FillComplementaryActivities()
        {
            lbComplementaryActivities.Items.Clear();
            lbComplementaryActivities.Items.Add("Quitar Actividad Complementaria del Horario");
            SqlString = "Select Numero,Nombre From ActComp";
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
            while (dr.Read())
            {
                lbComplementaryActivities.Items.Add(dr["Numero"].ToString() + "  " + dr["Nombre"].ToString());
            }
            DataBaseUtilities.CloseConnection();
        }

        private void DragEnterTeacher(int nRow, int nColumn)
        {
            DROP[0] = DataSchedule[nRow][nColumn];
            SqlString = "SELECT ClaveHM,Grupo,Materia,Maestro FROM HorarioMaterias WHERE Maestro='" + cmbGroups.Text + "' AND Hora='" + DROP[0].Hour + "' AND Dia='" + DROP[0].Day + "'";
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
            dr.Read();
            if (dr.HasRows)
            {
                DROP[0].Key = Convert.ToInt32(dr["ClaveHM"]);
                DROP[0].Group = dr["Grupo"].ToString();
                DROP[0].Subject = dr["Materia"].ToString();
                DROP[0].Teacher = dr["Maestro"].ToString();
            }
            else
            {
                SqlString = "SELECT ClaveHM,Grupo,Materia,Maestro FROM HorarioMaterias WHERE Grupo='" + DRAG[0].Group + "' AND Hora='" + DROP[0].Hour + "' AND Dia='" + DROP[0].Day + "'";
                OleDbDataReader dr1 = DataBaseUtilities.ExecuteSql(SqlString);
                dr1.Read();
                if (dr1.HasRows)
                {
                    DROP[0].Key = Convert.ToInt32(dr1["ClaveHM"]);
                    DROP[0].Group = dr1["Grupo"].ToString();
                    DROP[0].Subject = dr1["Materia"].ToString();
                    DROP[0].Teacher = dr1["Maestro"].ToString();
                }
            }
            DataBaseUtilities.CloseConnection();
        }

        private void DragDropLB(string Day, string Hour, int nRow, int nColumn)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            if (lbComplementaryActivities.SelectedItem.ToString() == "Quitar Actividad Complementaria del Horario")
            {
                VisualSchedule[nRow][nColumn].Text = "";
                VisualSchedule[nRow][nColumn].BackColor = Color.White;
                OleDbDataReader dr = DataBaseUtilities.ExecuteSql("Select ClaveHM From HorarioMaterias Where Maestro='" + cmbGroups.Text + "' and Hora='" + Hour + "' and Dia='" + Day + "'");
                dr.Read();
                if (dr.HasRows)
                {
                    SqlString = "DELETE FROM HorarioMaterias WHERE ClaveHM=" + Convert.ToInt32(dr["ClaveHM"]) + "";
                    DataBaseUtilities.ExecuteNonSql(SqlString);
                }
            }
            else
            {
                OleDbDataReader dr = DataBaseUtilities.ExecuteSql("Select ClaveHM,Materia From HorarioMaterias Where Maestro='" + cmbGroups.Text + "' and Dia='" + Day + "' and Hora='" + Hour + "'");
                dr.Read();
                if (dr.HasRows)
                {
                    if (dr["Materia"].ToString() != lbComplementaryActivities.SelectedItem.ToString())
                    {
                        SqlString = "UPDATE HorarioMaterias SET Materia='" + lbComplementaryActivities.SelectedItem.ToString() + "' Where ClaveHM=" + Convert.ToInt32(dr["ClaveHM"]) + "";
                        System.Threading.Thread.Sleep(100);
                        DataBaseUtilities.ExecuteNonSql(SqlString);
                    }
                }
                else
                {
                    SqlString = "Insert Into HorarioMaterias (Materia,Maestro,Hora,Dia,Turno,PosicionFila,PosicionColumna) Values ('" + lbComplementaryActivities.SelectedItem.ToString() + "','" + cmbGroups.Text + "','" + Hour + "','" + Day + "','" + cmbShift.Text + "'," + nRow + "," + nColumn + ")";
                    System.Threading.Thread.Sleep(100);
                    DataBaseUtilities.ExecuteNonSql(SqlString);
                }
            }
            DataBaseUtilities.CloseConnection();
        }

        private string JustifyString(string sText)
        {
            int Count=0;
            string sNewString = "";
            for (int nChar = 0; nChar < sText.Length; nChar++)
            {
                if (Count == 16)
                {
                    sNewString = sNewString + Environment.NewLine;
                    Count = 0;
                }
                sNewString = sNewString + sText[nChar];
                Count++;
            }
            return sNewString;
        }

        public bool InicializeSchedule(string sScheduleType)
        {
            VisualSchedule = new SimpleButton[][]
            {
                new SimpleButton[]{HA1,HA2,HA3,HA4,HA5},
                new SimpleButton[]{HA6,HA7,HA8,HA9,HA10},
                new SimpleButton[]{HA11,HA12,HA13,HA14,HA15},
                new SimpleButton[]{HA16,HA17,HA18,HA19,HA20},
                new SimpleButton[]{HA21,HA22,HA23,HA24,HA25},
                new SimpleButton[]{HA26,HA27,HA28,HA29,HA30},
                new SimpleButton[]{HA31,HA32,HA33,HA34,HA35}
            }; 
            if (sScheduleType == "Grupo")
            {
                cmbGroups.Properties.Properties.Items.Clear();
                DataBaseUtilities.OpenConnection(PathDataBase);
                cmbGroups = DataBaseUtilities.FillComboBoxEdit("Select Grupo From MaestroMateria", "Grupo", cmbGroups);
                DataBaseUtilities.CloseConnection();
                if (cmbGroups.Properties.Items.Count == 0)
                {
                    MessageBox.Show("En este momento no existen grupos!!");
                    return false;
                }
                else
                {
                    cmbGroups.Text = cmbGroups.Properties.Items[0].ToString();
                    InicilazeDatachedule();
                    FilllbSchedule();
                    FillSchedules();
                    AssignColor();
                    return true;
                }
            }
            else
            {
                groupBoxDatos.Text = "Informacion de Maestro";
                cmbShift.Visible = true;
                cmbGroups.Width = 268;
                DataBaseUtilities.OpenConnection(PathDataBase);
                cmbGroups = DataBaseUtilities.FillComboBoxEdit("Select Nombre From Personal WHERE Puesto='DOCENTE'", "Nombre", cmbGroups);
                DataBaseUtilities.CloseConnection();
                if (cmbGroups.Properties.Items.Count == 0)
                {
                    MessageBox.Show("En este momento no existen Horarios!!");
                    return false;
                }
                else
                {
                    cmbGroups.Properties.Properties.Items.Clear();
                    cmbScheduleType.Text = "Maestro";
                    return true;                
                }

            }
        }

        # endregion      
    }
}
