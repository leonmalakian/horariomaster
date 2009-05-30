using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HorarioMaster.Controls;
using System.IO;
using System.Data.OleDb;
using HorarioMaster;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace HorarioMaster.Controls
{
    public partial class GridControlPersonal : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlPersonal()
        {
            InitializeComponent();
        }

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        static string sName = "";
        public delegate void GridUpdate();
        public static event GridUpdate UpdateGrid;   
        #endregion

        private void grdPersonal_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select Numero,NumeroTarjeta,Nombre,Sexo,RFC,CURP,Direccion,Colonia,CP,Localidad,Telefono,Celular,Email,INGGF,INGSEP,INGDGETI,Perfil,Puesto,Nombramiento,Descarga,NivelMaxEstudios,Actividad,Nivel,Sub,Catego,MOV,Un,HS From Personal");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdPersonal.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            AddPopupColumn("Plaza", "Asignar Plaza...");
            AddComboBoxColumn("","Masculino,Femenino", "Sexo","");
            AddComboBoxColumn("","0,1,2,3,4,5,6,7,8,9,10", "Descarga","");
            AddComboBoxColumn("","Sin Estudios,Primaria,Carrera Comercial,Carrera Tecnica,Secundaria,Bachillerato,Normal,Normal Superior,Licenciatura,Maestria,Doctorado,Tecnico Superior,Licenciatura Tecnica", "NivelMaxEstudios","");
            AddComboBoxColumn("","Docente,Administrativo", "Actividad","");
            AddComboBoxColumn("","Pasante,Titulado,Otro", "Nivel","");
            AddComboBoxColumn("","03,27", "Sub","");
            AddComboBoxColumn("Select Clave From Clave","", "Catego", "Clave");
            AddComboBoxColumn("","10,25,95", "MOV","");
            AddDateColumn("INGGF");
            AddDateColumn("INGSEP");
            AddDateColumn("INGDGETI");
            AddTextEditColumn("Telefono");
            AddTextEditColumn("Celular");
            HeadersColumnsNames("Numero,Numero de Tarjeta,Nombre,Sexo,RFC,CURP,Direccion,Colonia,CP,Localidad,Telefono de Casa,Telefono Celular,Correo Electronico,INGGF,INGSEP,INGDGETI,Perfil,Puesto,Nombramiento,Descarga,Nivel Maximo de Estudios,Actividad,Nivel,Subcategoria,Clave,Movimiento,Unidad,Horas");
            gridView1.BestFitColumns();
        }

        public void AddComboBoxColumn(string sSql, string sItem, string sColumnNameReplace, string sFieldChargeComboBox)
        {
            RepositoryItemComboBox Temp = new RepositoryItemComboBox();
            Temp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            if (sSql != "")
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                Temp = DataBaseUtilities.FillRepositoryItemComboBox(sSql, sFieldChargeComboBox, Temp);
                (grdPersonal.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            }
            else
            {
                string[] ArrayItems = sItem.Split(',');
                for (int nIndex = 0; nIndex < ArrayItems.Length; nIndex++)
                {
                    Temp.Items.Add(ArrayItems[nIndex]);
                }
                (grdPersonal.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            }           
        }

        public void AddDateColumn(string sColumnNameReplace)
        {
            RepositoryItemDateEdit temp = new RepositoryItemDateEdit();
            grdPersonal.RepositoryItems.Add(temp);
            (grdPersonal.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = temp;

        }

        public void AddTextEditColumn(string sColumnNameReplace)
        {
            RepositoryItemTextEdit temp = new RepositoryItemTextEdit();
            temp.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            temp.Mask.EditMask = "(000)000-00-00";
            grdPersonal.RepositoryItems.Add(temp);
            (grdPersonal.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = temp;

        }

        public void AddPopupColumn(string sColumnNameCreate, string sText)
        {
            RepositoryItemPopupContainerEdit temp = new RepositoryItemPopupContainerEdit();
            grdPersonal.RepositoryItems.Add(temp);
            tabla.Columns.Add(sColumnNameCreate);
            gridView1.Columns.Add();
            grdPersonal.MainView.BeginDataUpdate();
            gridView1.PopulateColumns();
            grdPersonal.MainView.EndDataUpdate();
            temp.NullText = sText;
            (grdPersonal.MainView as GridView).Columns.ColumnByFieldName(sColumnNameCreate).ColumnEdit = temp;
            gridView1.BestFitColumns();
            temp.Click += new EventHandler(temp_Click);
        }

        void temp_Click(object sender, EventArgs e)
        {
           frmGridPlaza frmPlaza = new frmGridPlaza(sName);
           frmPlaza.StartPosition = FormStartPosition.CenterScreen;
           frmPlaza.ShowDialog();
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            gridView1.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            for (int nColumn = 0; nColumn < CurrentRow.Row.ItemArray.Length; nColumn++)
            {
                if (CurrentRow.Row["Numero"].ToString().Length > 4)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns["Numero"].ToString() + " no debe ser mayor de 4 digitos", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["Numero"], "Este Campo no debe ser mayor de 4 digitos");
                    return;
                }
                if (CurrentRow.Row["NumeroTarjeta"].ToString().Length > 4)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns["NumeroTarjeta"].ToString() + " no debe ser mayor de 4 digitos", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["NumeroTarjeta"], "Este Campo no debe ser mayor de 4 digitos");
                    return;
                }
                if (CurrentRow.Row["CP"].ToString().Length > 5)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns["CP"].ToString() + " no debe ser mayor de 5 digitos", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["CP"], "Este Campo no debe ser mayor de 5 digitos");
                    return;
                }
                if (CurrentRow.Row["RFC"].ToString().Length > 13)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns["RFC"].ToString() + " no debe ser mayor de 13 digitos", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["RFC"], "Este Campo no debe ser mayor de 13 digitos");
                    return;
                }
                if (CurrentRow.Row["CURP"].ToString().Length > 18)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns["CURP"].ToString() + " no debe ser mayor de 18 digitos", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["CURP"], "Este Campo no debe ser mayor de 18 digitos");
                    return;
                }
                if (CurrentRow.Row[nColumn].ToString() == "" && nColumn!=28)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns[nColumn].ToString() + " no debe estar vacio", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns[nColumn], "Este Campo no debe ser vacio");
                    return;
                }
                if (gridView1.Columns[nColumn].Name == "colNumero" || gridView1.Columns[nColumn].Name == "colNumeroTarjeta" || gridView1.Columns[nColumn].Name == "colCP"
                    || gridView1.Columns[nColumn].Name == "colUn" || gridView1.Columns[nColumn].Name == "colHS")
                {
                    if (!IsNumeric(CurrentRow.Row[nColumn]))
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(gridView1.Columns[nColumn].ToString() + " debe ser Numerico", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridView1.SetColumnError(gridView1.Columns[nColumn], "Este campo debe ser Numerico");
                        return;
                    }
                }      
            }
            for (int nRow = 0; nRow < tabla.Rows.Count; nRow++)
            {
                if (CurrentRow.IsNew)
                {
                    if (CurrentRow.Row["Nombre"].ToString() == tabla.Rows[nRow].ItemArray[2].ToString())
                    {
                        e.Valid = false;
                        XtraMessageBox.Show("Esta persona ya esta dada de alta", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridView1.SetColumnError(gridView1.Columns["Nombre"], "No debe de haber personas repetidos");
                        return;
                    }
                }
                else
                {
                    if (nRow!=e.RowHandle)
                    {
                        if (CurrentRow.Row["Nombre"].ToString() == tabla.Rows[nRow].ItemArray[2].ToString())
                        {
                            e.Valid = false;
                            XtraMessageBox.Show("Esta persona ya esta dada de alta", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            gridView1.SetColumnError(gridView1.Columns["Nombre"], "No debe de haber personas repetidos");
                            return;
                        }
                    }
                }
            }
            
        }

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        public static bool IsNumeric(object Cadena)
        {
            bool isNumber;
            double isItNumeric;
            isNumber = Double.TryParse(Convert.ToString(Cadena), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out isItNumeric);
            return isNumber;
        }

        private void HeadersColumnsNames(string sHeaders)
        {
            int nColumnIndex = 0;
            foreach (string sHeader in sHeaders.Split(','))
            {
                gridView1.Columns[nColumnIndex].Caption = sHeader;
                gridView1.Columns[nColumnIndex].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                nColumnIndex++;
            }
        }

        private void gridView1_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                cmnuPersonal.Show(view.GridControl, e.Point);
            }
        }

        private void cmnuItemBorrar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas seguro que deseas borrar este registro?", "Borrar Registro", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                this.da.Update((DataTable)Binding1.DataSource);
                gridView1.BestFitColumns();
                UpdateGrid();
            }
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.da.Update((DataTable)Binding1.DataSource);
            Binding1.DataSource = tabla;
            grdPersonal.DataSource = Binding1;
            gridView1.BestFitColumns();
            UpdateGrid();
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                sName = tabla.Rows[e.FocusedRowHandle].ItemArray[2].ToString();
            }
        }
    }
}
