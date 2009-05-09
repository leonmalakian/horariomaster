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
        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        #endregion

        #region Validation
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            ErrorProvider.ClearErrors();
            GetControls(this);


        }

        private void frmDatosPlantel_Load(object sender, EventArgs e)
        {          
           
        }

        public void GetControls(Control cControl)
        {            
            for (int nControl = 0; nControl < cControl.Controls.Count; nControl++)
            {
                if (cControl.Controls[nControl].Controls.Count > 0)
                {
                    GetControls(cControl.Controls[nControl]);
                }

                if (cControl.Controls[nControl].GetType().Name == "TextEdit" || cControl.Controls[nControl].GetType().Name == "DateEdit")
                {
                    if (cControl.Controls[nControl].Text == "")
                    {
                        ErrorProvider.SetError(cControl.Controls[nControl], "Este Campo no debe estar en blanco");
                    }
                }
            }
        }
        #endregion
    }
}