using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HorarioMaster;
using System.IO;
using System.Data.OleDb;
using HorarioMaster.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace HorarioMaster.UI
{
    public partial class frmDatosPlantel : DevExpress.XtraEditors.XtraForm
    {
        public frmDatosPlantel()
        {
            InitializeComponent();
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text != "" && textEdit2.Text !="" && textEdit3.Text != "" && textEdit4.Text !="" && textEdit5.Text != "" && textEdit6.Text != "" && textEdit7.Text != "" && textEdit8.Text != "" && textEdit9.Text != "")
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                //INSERT INTO Plantel()
            }

            if(textEdit1.Text == ""||textEdit2.Text == ""||textEdit3.Text == ""||textEdit4.Text == ""||textEdit5.Text == ""||textEdit6.Text == ""||textEdit7.Text == ""||textEdit8.Text == ""||textEdit9.Text == "")
            {
                List<object> Err = new List<object>();
                //Err.Add(object);
                textEdit1.ErrorText = "El campo no debe de estar vacio";
                Data_Error();
            }

        }

        private void Data_Error()
        {
            MessageBox.Show("El campo no debe de estar vacio");
        }
    }
}