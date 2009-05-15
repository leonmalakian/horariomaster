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

        #region SaveParams
        private void Save_Params()
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            string str = "INSERT INTO Plantel (Nombre,Clave,Municipio,Direccion,Director,Subdirector,Matutino,Vespertino,Fecha,Periodo)VALUES('" + txtNombrePlantel.Text + "','" + txtClavePlantel.Text + "','" + txtEntidadFederativa.Text + "','" + txtDireccionPlantel.Text + "','" + txtDirector.Text + "','" + txtSubdirector.Text + "','" + txtTurnoMatutino.Text + "','" + txtTurnoVespertino.Text + "','" + dateFecha.Text + "','" + txtPeriodo.Text + "')";
            DataBaseUtilities.ExecuteNonSql(str);
            DataBaseUtilities.CloseConnection();
        }
        #endregion

        #region Validation
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            ErrorProvider.ClearErrors();
            GetControls(this);
            Save_Params();
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