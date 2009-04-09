using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using HorarioMaster;


namespace frmHorario
{
    public partial class frmHorario : Form
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
        private static string[] HoursMorning = new string[] { "7:00-8:00", "8:00-9:00", "9:00-10:00", "10:00-11:00", "11:00-12:00", "12:00-13:00", "13:00-14:00" };
        private static string[] HoursEvening = new string[] { "14:00-15:00", "15:00-16:00", "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00", "21:00-22:00" };
        private static Label[][] VisualSchedule;
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
            e.Effect = DragDropEffects.Move;          
        }

        private void HA1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;            
        }

        private void HA1_MouseDown(object sender, MouseEventArgs e)
        {
            DRAG[0] = DataSchedule[0][0];            
            HA1.DoDragDrop(HA1, DragDropEffects.Link);
        }

        private void HA2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            DRAG[1] = DRAG[0];
            SqlString = @"Select ClaveHM,Materia,Grupo 
                          From HorarioMaterias 
                          Where Dia='Martes' AND Hora='7:00-8:00' AND Maestro='" + DRAG[0].Teacher + "' AND Grupo<>'" + DRAG[0].Group + "'";
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
            dr.Read();
            DRAG[1].Key = Convert.ToInt32(dr["ClaveHM"]);
            DRAG[1].Subject = dr["Materia"].ToString();
            DRAG[1].Group = dr["Grupo"].ToString();
            DataBaseUtilities.CloseConnection();
            //DROP[1] = DataSchedule[0][1];
            e.Effect = DragDropEffects.Move;
        }

        private void HA2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            DROP[0] = DataSchedule[0][1];            
            e.Effect = DragDropEffects.Link;            
        }

        private void HA2_MouseDown(object sender, MouseEventArgs e)
        {            
            HA2.DoDragDrop(HA2, DragDropEffects.Link);
        }

        private void HA3_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;         
        }

        private void HA3_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void HA3_MouseDown(object sender, MouseEventArgs e)
        {
            HA3.DoDragDrop(HA3, DragDropEffects.Link);
        }

        private void HA4_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;                   
        }

        private void HA4_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA4_MouseDown(object sender, MouseEventArgs e)
        {
            HA4.DoDragDrop(HA4, DragDropEffects.Link);
        }

        private void HA5_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {           
                    e.Effect = DragDropEffects.Move;
        
        }

        private void HA5_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA5_MouseDown(object sender, MouseEventArgs e)
        {
            HA5.DoDragDrop(HA5, DragDropEffects.Link);
        }

        private void HA6_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
                    e.Effect = DragDropEffects.Move;
           
        }

        private void HA6_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA6_MouseDown(object sender, MouseEventArgs e)
        {
            HA6.DoDragDrop(HA6, DragDropEffects.Link);
        }

        private void HA7_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
                    e.Effect = DragDropEffects.Move;
            
        }

        private void HA7_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

         

        }

        private void HA7_MouseDown(object sender, MouseEventArgs e)
        {
            HA7.DoDragDrop(HA7, DragDropEffects.Link);
        }

        private void HA8_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            
                    e.Effect = DragDropEffects.Move;
          
        }

        private void HA8_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA8_MouseDown(object sender, MouseEventArgs e)
        {
            HA8.DoDragDrop(HA8, DragDropEffects.Link);
        }

        private void HA9_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
                    e.Effect = DragDropEffects.Move;
        
        }

        private void HA9_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        
        }

        private void HA9_MouseDown(object sender, MouseEventArgs e)
        {
            HA9.DoDragDrop(HA9, DragDropEffects.Link);
        }

        private void HA10_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA10_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA10_MouseDown(object sender, MouseEventArgs e)
        {
            HA10.DoDragDrop(HA10, DragDropEffects.Link);
        }

        private void HA11_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA11_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA11_MouseDown(object sender, MouseEventArgs e)
        {
            HA11.DoDragDrop(HA11, DragDropEffects.Link);
        }

        private void HA12_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA12_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA12_MouseDown(object sender, MouseEventArgs e)
        {
            HA12.DoDragDrop(HA12, DragDropEffects.Link);
        }

        private void HA13_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA13_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;


        }

        private void HA13_MouseDown(object sender, MouseEventArgs e)
        {
            HA13.DoDragDrop(HA13, DragDropEffects.Link);
        }

        private void HA14_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA14_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA14_MouseDown(object sender, MouseEventArgs e)
        {
            HA14.DoDragDrop(HA14, DragDropEffects.Link);
        }

        private void HA15_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA15_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA15_MouseDown(object sender, MouseEventArgs e)
        {
            HA15.DoDragDrop(HA15, DragDropEffects.Link);
        }

        private void HA16_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA16_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA16_MouseDown(object sender, MouseEventArgs e)
        {
            HA16.DoDragDrop(HA16, DragDropEffects.Link);
        }

        private void HA17_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA17_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA17_MouseDown(object sender, MouseEventArgs e)
        {
            HA17.DoDragDrop(HA17, DragDropEffects.Link);
        }

        private void HA18_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA18_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA18_MouseDown(object sender, MouseEventArgs e)
        {
            HA18.DoDragDrop(HA18, DragDropEffects.Link);
        }

        private void HA19_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void HA19_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA19_MouseDown(object sender, MouseEventArgs e)
        {
            HA19.DoDragDrop(HA19, DragDropEffects.Link);
        }

        private void HA20_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA20_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA20_MouseDown(object sender, MouseEventArgs e)
        {
            HA20.DoDragDrop(HA20, DragDropEffects.Link);
        }

        private void HA21_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA21_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;


        }

        private void HA21_MouseDown(object sender, MouseEventArgs e)
        {
            HA21.DoDragDrop(HA21, DragDropEffects.Link);
        }

        private void HA22_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA22_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA22_MouseDown(object sender, MouseEventArgs e)
        {
            HA22.DoDragDrop(HA22, DragDropEffects.Link);
        }

        private void HA23_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA23_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA23_MouseDown(object sender, MouseEventArgs e)
        {
            HA23.DoDragDrop(HA23, DragDropEffects.Link);
        }

        private void HA24_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA24_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA24_MouseDown(object sender, MouseEventArgs e)
        {
            HA24.DoDragDrop(HA24, DragDropEffects.Link);
        }

        private void HA25_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA25_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA25_MouseDown(object sender, MouseEventArgs e)
        {
            HA25.DoDragDrop(HA25, DragDropEffects.Link);
        }

        private void HA26_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA26_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA26_MouseDown(object sender, MouseEventArgs e)
        {
            HA26.DoDragDrop(HA26, DragDropEffects.Link);
        }

        private void HA27_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA27_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA27_MouseDown(object sender, MouseEventArgs e)
        {
            HA27.DoDragDrop(HA27, DragDropEffects.Link);
        }

        private void HA28_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA28_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA28_MouseDown(object sender, MouseEventArgs e)
        {
            HA28.DoDragDrop(HA28, DragDropEffects.Link);
        }

        private void HA29_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA29_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA29_MouseDown(object sender, MouseEventArgs e)
        {
            HA29.DoDragDrop(HA29, DragDropEffects.Link);
        }

        private void HA30_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA30_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA30_MouseDown(object sender, MouseEventArgs e)
        {
            HA30.DoDragDrop(HA30, DragDropEffects.Link);
        }

        private void HA31_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA31_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA31_MouseDown(object sender, MouseEventArgs e)
        {
            HA31.DoDragDrop(HA31, DragDropEffects.Link);
        }

        private void HA32_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA32_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;


        }

        private void HA32_MouseDown(object sender, MouseEventArgs e)
        {
            HA32.DoDragDrop(HA32, DragDropEffects.Link);
        }

        private void HA33_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA33_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA33_MouseDown(object sender, MouseEventArgs e)
        {
            HA33.DoDragDrop(HA33, DragDropEffects.Link);
        }

        private void HA34_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA34_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

        }

        private void HA34_MouseDown(object sender, MouseEventArgs e)
        {
            HA34.DoDragDrop(HA34, DragDropEffects.Link);
        }

        private void HA35_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void HA35_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
         
        }

        private void HA35_MouseDown(object sender, MouseEventArgs e)
        {
            HA35.DoDragDrop(HA35, DragDropEffects.Link);
        }

        #endregion
        
        # region Controls events

        private void frmHorario_Load(object sender, EventArgs e)
        {
            VisualSchedule = new Label[][]
            {
                new Label[]{HA1,HA2,HA3,HA4,HA5},
                new Label[]{HA6,HA7,HA8,HA9,HA10},
                new Label[]{HA11,HA12,HA13,HA14,HA15},
                new Label[]{HA16,HA17,HA18,HA19,HA20},
                new Label[]{HA21,HA22,HA23,HA24,HA25},
                new Label[]{HA26,HA27,HA28,HA29,HA30},
                new Label[]{HA31,HA32,HA33,HA34,HA35}
            };
            cmbGroups.Items.Clear();
            DataBaseUtilities.OpenConnection(PathDataBase);
            cmbGroups = DataBaseUtilities.FillComboBox("Select Grupo From MaestroMateria", "Grupo", cmbGroups);
            DataBaseUtilities.CloseConnection();
            if (cmbGroups.Items.Count == 0)
            {
                MessageBox.Show("En este momento no existen grupos!!");
                //this.Close();
            }
            else
            {
                cmbGroups.Text = cmbGroups.Items[0].ToString();
                InicilazeDatachedule();
                FilllbSchedule();
                FillSchedules();
            }            
        }

        private void ScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {            
            cmbGroups.Items.Clear();
            cmbGroups.Text = "";
            if (cmbScheduleType.Text == "Grupo")
            {
                groupBoxDatos.Text = "Informacion de Grupo";
                cmbShift.Visible = false;
                cmbGroups.Width = 57;
                DataBaseUtilities.OpenConnection(PathDataBase);
                cmbGroups = DataBaseUtilities.FillComboBox("Select Grupo From MaestroMateria", "Grupo", cmbGroups);
                DataBaseUtilities.CloseConnection();  
                cmbGroups.Text = cmbGroups.Items[0].ToString();                
                SqlString = "Select Especialidad,Turno From Grupos Where SG ='" + cmbGroups.Text + "'";
                DataBaseUtilities.OpenConnection(PathDataBase);
                Especialidad.Text = DataBaseUtilities.ReturnRecord("Select Especialidad From Grupos Where SG ='" + cmbGroups.Text + "'", "Especialidad").ToString();
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                Turno.Text = DataBaseUtilities.ReturnRecord("Select Turno From Grupos Where SG ='" + cmbGroups.Text + "'", "Turno").ToString();
                DataBaseUtilities.CloseConnection();               
                LimpiarHorario.Visible = true;
                Turno.Visible = true;
                FilllbSchedule();
            }
            else
            {
                groupBoxDatos.Text = "Informacion de Maestro";
                cmbShift.Visible = true;
                cmbGroups.Width = 268;
                DataBaseUtilities.OpenConnection(PathDataBase);
                cmbGroups = DataBaseUtilities.FillComboBox("Select Nombre From Personal WHERE Puesto='DOCENTE'", "Nombre", cmbGroups);
                DataBaseUtilities.CloseConnection();
                cmbGroups.Text = cmbGroups.Items[0].ToString();               
                Turno.Visible = false;
                FilllbSchedule();
            }
        }

        private void Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicilazeDatachedule();
            if (cmbScheduleType.Text == "Grupo")
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                Especialidad.Text = DataBaseUtilities.ReturnRecord("Select Especialidad From Grupos Where SG ='" + cmbGroups.Text + "'", "Especialidad").ToString();
                DataBaseUtilities.CloseConnection();
                DataBaseUtilities.OpenConnection(PathDataBase);
                Turno.Text = DataBaseUtilities.ReturnRecord("Select Turno From Grupos Where SG ='" + cmbGroups.Text + "'", "Turno").ToString();
                DataBaseUtilities.CloseConnection();               
               
            }
            FilllbSchedule();
            FillSchedules();
        }

        private void CmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicilazeDatachedule();
            FilllbSchedule();
            FillSchedules();
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
//            SqlString = @"SELECT DISTINCT MaestroMateria.Maestro, MaestroMateria.Grupo, Materias.Nombre, Materias.HC
//                          FROM MaestroMateria INNER JOIN Materias ON (MaestroMateria.Materia = Materias.Nombre) AND (MaestroMateria.Grupo = Materias.SG)
//                          WHERE (((MaestroMateria.Grupo)='" + cmbGroups.Text + "'));";
            SqlString = @"SELECT MaestroMateria.Maestro, MaestroMateria.Grupo, MaestroMateria.Materia, Materias.HC
                          FROM Materias INNER JOIN MaestroMateria ON Materias.Clave = MaestroMateria.Clave
                          WHERE (((MaestroMateria.Grupo)='" + cmbGroups.Text + "'));";
            
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);            
            while (dr.Read())
            {
                if (!DataBaseUtilities.RecordExist("Select Materia From HorarioMaterias Where Materia='" + dr["Materia"].ToString() + "' AND Grupo='"+cmbGroups.Text+"'"))
                {
                    DataFieldtemp.Teacher = dr["Maestro"].ToString();
                    DataFieldtemp.Subject = dr["Materia"].ToString();
                    DataFieldtemp.Hour = dr["HC"].ToString();
                    DataFieldtemp.Group = cmbGroups.Text;
                    DataFieldTempList.Add(DataFieldtemp);
                }                
            }
            DataBaseUtilities.CloseConnection();
            foreach(DataField DataFieldTemp in DataFieldTempList)
            {
                nHour = Convert.ToInt32(DataFieldTemp.Hour);
                while (nHour > 0)
                {
                    nHour=nHour-1;
                    for (int nRow = 0; nRow < 7; nRow++)
                    {                       
                        for (int nColumn = 0; nColumn < 5; nColumn++)
                        {
                            DataBaseUtilities.OpenConnection(PathDataBase);
//                            SqlString = "Select Materia From HorarioMaterias Where Grupo='" + cmbGroups.Text + "' And PosicionFila="+nRow+@"
//                                         And PosicionColumna="+nColumn+"";
                            SqlString = @"SELECT HorarioMaterias.Materia FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                                          WHERE (((HorarioMaterias.Dia)='" + DataSchedule[nRow][nColumn].Day + "') AND ((HorarioMaterias.Hora)='" + DataSchedule[nRow][nColumn].Hour + "') AND ((MaestroMateria.Maestro)='" + DataFieldTemp.Teacher + @"') OR 
                                          ((HorarioMaterias.Dia)='" + DataSchedule[nRow][nColumn].Day + "') AND ((HorarioMaterias.Hora)='" + DataSchedule[nRow][nColumn].Hour + "') AND ((MaestroMateria.Grupo)='" + cmbGroups.Text + "'))";
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
            string sShift = null;
            lbSchedule.Items.Clear();
            if (cmbScheduleType.Text == "Grupo")
            { sShift = GetShiftGroup(); }
            else { sShift = cmbShift.Text; }
            if (sShift == "MATUTINO")
            {
                foreach (string Hour in HoursMorning)
                {
                    lbSchedule.Items.Add(Hour);
                    lbSchedule.Items.Add("");
                    lbSchedule.Items.Add("");
                }
            }
            else
            {
                foreach (string Hour in HoursEvening)
                {
                    lbSchedule.Items.Add(Hour);
                    lbSchedule.Items.Add("");
                    lbSchedule.Items.Add("");
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
                    VisualSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Text = dr["Materia"].ToString();
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
                SqlString = @"SELECT HorarioMaterias.Materia, HorarioMaterias.PosicionColumna,HorarioMaterias.PosicionFila,HorarioMaterias.Grupo, HorarioMaterias.ClaveHM, MaestroMateria.Maestro
                              FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                              WHERE (((HorarioMaterias.Maestro)='" + cmbGroups.Text + "' AND (HorarioMaterias.Turno)='" + cmbShift.Text + "'))";
                OleDbDataReader dr = DataBaseUtilities.ExecuteSql(SqlString);
                while (dr.Read())
                {
                    VisualSchedule[Convert.ToInt32(dr["PosicionFila"])][Convert.ToInt32(dr["PosicionColumna"])].Text = dr["Materia"].ToString();
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
                    VisualSchedule[Fila][Columna].BackColor = Color.White;
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
        # endregion    

        private void button2_Click(object sender, EventArgs e)
        {
            MaestroMateria mm = new MaestroMateria();
            mm.Show();
        }
    }
}
