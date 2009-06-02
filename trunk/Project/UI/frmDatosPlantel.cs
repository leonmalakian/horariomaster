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
        bool bExist;
        public delegate void Refresh_form();
        public static event Refresh_form refresh_portada;
        #endregion

        #region SaveParams
        private void Save_Params()
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            string str = "INSERT INTO Plantel (Nombre,Clave,Municipio,Direccion,Director,Subdirector,Matutino,Vespertino,Fecha,Periodo)VALUES('" + txtNombrePlantel.Text + "','" + txtClavePlantel.Text + "','" + txtEntidadFederativa.Text + "','" + txtDireccionPlantel.Text + "','" + txtDirector.Text + "','" + txtSubdirector.Text + "','" + txtTurnoMatutino.Text + "','" + txtTurnoVespertino.Text + "','" + dateFecha.Text + "','" + txtPeriodo.Text + "')";
            DataBaseUtilities.ExecuteNonSql(str);
            refresh_portada();
            DataBaseUtilities.CloseConnection();
        }
        #endregion

        #region LoadParams
        private void Load_Params()
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataReader dr = DataBaseUtilities.ExecuteSql("Select * From Plantel");
            while (dr.Read())
            {
                txtNombrePlantel.Text = dr["Nombre"].ToString();
                txtClavePlantel.Text = dr["Clave"].ToString();
                txtEntidadFederativa.Text = dr["Municipio"].ToString();
                txtDireccionPlantel.Text = dr["Direccion"].ToString();
                txtDirector.Text = dr["Director"].ToString();
                txtSubdirector.Text = dr["Subdirector"].ToString();
                txtTurnoMatutino.Text = dr["Matutino"].ToString();
                txtTurnoVespertino.Text = dr["Vespertino"].ToString();
                dateFecha.Text = dr["Fecha"].ToString();
                txtPeriodo.Text = dr["Periodo"].ToString();
            }
            DataBaseUtilities.CloseConnection();
        }
        #endregion

        #region UpdateParams
        private void Update_Params()
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            string str = "update Plantel set Nombre='" + txtNombrePlantel.Text + "', Clave='" + txtClavePlantel.Text +
                          "',Municipio='" + txtEntidadFederativa.Text + "',Direccion='" + txtDireccionPlantel.Text +
                          "',Director='" + txtDirector.Text + "',Subdirector='" + txtSubdirector.Text +
                          "',Matutino='" + txtTurnoMatutino.Text + "',Vespertino='" + txtTurnoVespertino.Text +
                          "',Fecha='" + dateFecha.Text + "',Periodo='" + txtPeriodo.Text + "'";
            DataBaseUtilities.ExecuteNonSql(str);
            refresh_portada();
            DataBaseUtilities.CloseConnection();
        }
        #endregion

        #region Events
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            ErrorProvider.ClearErrors();
            GetControls(this);
            if (bExist == false)
            {
                Save_Params();
            }
            else
            {
                Update_Params();
            }
            DataBaseUtilities.CloseConnection();
        }
        #endregion

        #region Validation
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

        #region Load_Form
        private void frmDatosPlantel_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            bExist = DataBaseUtilities.RecordExist("Select * From Plantel");
            if (bExist == true)
            {
                Load_Params();
                BtnGrabar.Text = "Actualizar";
            }
            else
            {
                Save_Params();
            }
            DataBaseUtilities.CloseConnection();
        }
        #endregion
    }
}