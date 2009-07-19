using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.OleDb;

namespace HorarioMaster.UI
{
    public partial class frmPortada : DevExpress.XtraEditors.XtraForm
    {
        public frmPortada()
        {
            InitializeComponent();
            frmDatosPlantel.refresh_portada += new frmDatosPlantel.Refresh_form(frmDatosPlantel_refresh_portada);
        }

        void frmDatosPlantel_refresh_portada()
        {
            Load_DPlantel();
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private Padding mPadding = new Padding(8);
        private void frmPortada_Load(object sender, EventArgs e)
        {
            Load_DPlantel();
        }

        private void Load_DPlantel()
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql("Select Nombre,Imagen From Plantel");
            while (dr.Read())
            {
                if (dr["Nombre"] != null)
                {
                    label1.Text = dr["Nombre"].ToString();
                    label1.Left = mPadding.Left;
                    label1.Top = mPadding.Top;
                    int width = Width - mPadding.Right - mPadding.Left;
                    label1.Width = width > 0 ? width : 0;
                    int heigth = Height - mPadding.Bottom - mPadding.Top;
                    label1.Height = heigth > 0 ? heigth : 0;
                }
                if (dr["Imagen"] != null)
                {
                    if (File.Exists(dr["Imagen"].ToString()))
                    {
                        //pictureBox1.Text = dr["Nombre"].ToString();
                        //pictureBox1.Left = mPadding.Left;
                        ////pictureBox1.Top = label1.Bottom;
                        //int width = Width - mPadding.Right - mPadding.Left;
                        //pictureBox1.Width = width > 0 ? width : 0;
                        int heigth = Height - mPadding.Bottom - mPadding.Top;
                        pictureBox1.Height = heigth > 0 ? heigth : 0;

                        
                        pictureBox1.Image = System.Drawing.Image.FromFile(dr["Imagen"].ToString());
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }

            }
            DataBaseUtilities.CloseConnection();
        }

        private void frmPortada_ParentChanged(object sender, EventArgs e)
        {
            //this.Size = Parent.Size;
        }

        private void frmPortada_Paint(object sender, PaintEventArgs e)
        {
            //this.Height = 2;
            //this.Size = Parent.Size;
        }
    }
}