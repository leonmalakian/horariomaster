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
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private Padding mPadding = new Padding(8);
        private void frmPortada_Load(object sender, EventArgs e)
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
                        pictureBox1.Image = System.Drawing.Image.FromFile(dr["Imagen"].ToString());
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                
            }
            DataBaseUtilities.CloseConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}