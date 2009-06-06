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
    public partial class GridControlAsignaMateria : DevExpress.XtraEditors.XtraUserControl
    {
        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        static string sName = "";
        static string sMateria = "";
        static string sClave = "";
        #endregion
        
        public GridControlAsignaMateria(string sNamePersonal)
        {
            sName = sNamePersonal;
            InitializeComponent();
        }       

        private void grdAsignaMateria_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From MaestroMateria Where Maestro='" + sName + "'");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);            
            Binding1.DataSource = tabla;
            grdAsignaMateria.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            AddComboBoxColumn("Select Clave From Materias Where Nombre=' '", "Clave", "Clave");
            AddComboBoxColumn("SELECT Nombre FROM Materias WHERE Nombre NOT IN(SELECT Materia FROM HorarioMaterias)", "Materia", "Nombre");
            gridView1.Columns["Index"].Visible = false;
            gridView1.Columns["Maestro"].Visible = false;
            HeadersColumnsNames(",,Materia,Clave de la Materia,Grupo");
            gridView1.BestFitColumns();
        }

        public void AddComboBoxColumn(string sSql, string sColumnNameReplace, string sFieldChargeComboBox)
        {
            RepositoryItemComboBox Temp = new RepositoryItemComboBox();
            Temp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            DataBaseUtilities.OpenConnection(PathDataBase);
            Temp = DataBaseUtilities.FillRepositoryItemComboBox(sSql, sFieldChargeComboBox, Temp);
            (grdAsignaMateria.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            DataBaseUtilities.CloseConnection();
        }
        
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "colMateria")
            {
                sMateria = e.Value.ToString(); ;
                AddComboBoxColumn("Select Clave From Materias Where Nombre='" + e.Value.ToString() + "'", "Clave", "Clave");
            }
            if (e.Column.Name == "colClave")
            {
                sClave = e.Value.ToString(); ;
            }
            AddComboBoxColumn("Select SG From Grupos Where SG NOT IN(SELECT Grupo FROM MaestroMateria Where Materia='" + sMateria + "' AND Clave='" + sClave +"')", "Grupo", "SG");
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            gridView1.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            for (int nColumn = 0; nColumn < CurrentRow.Row.ItemArray.Length; nColumn++)
            {
                if (CurrentRow.Row[nColumn].ToString() == "" && nColumn!=0)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns[nColumn].ToString() + " no debe estar vacio", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns[nColumn], "Este Campo no debe ser vacio");
                    return;
                }
            }            
        }

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.da.Update((DataTable)Binding1.DataSource);
            Binding1.DataSource = tabla;
            grdAsignaMateria.DataSource = Binding1;
            tabla.Clear();
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From MaestroMateria Where Maestro='" + sName + "'");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);            
            Binding1.DataSource = tabla;
            grdAsignaMateria.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
            gridView1.BestFitColumns();
        }

        private void cmnuBorrarItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas seguro que deseas borrar este registro?", "Borrar Registro", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                this.da.Update((DataTable)Binding1.DataSource);
                Binding1.DataSource = tabla;
                grdAsignaMateria.DataSource = Binding1;
                tabla.Clear();
                DataBaseUtilities.OpenConnection(PathDataBase);
                da = DataBaseUtilities.FillDataAdapter("Select * From MaestroMateria Where Maestro='" + sName + "'");
                OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
                this.da.Fill(tabla);
                Binding1.DataSource = tabla;
                grdAsignaMateria.DataSource = Binding1;
                DataBaseUtilities.CloseConnection();
                gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
                gridView1.BestFitColumns();
            }
        }

        private void gridView1_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                cmnuAsignaMateria.Show(view.GridControl, e.Point);
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "Maestro",sName);
            gridView1.Columns["Materia"].OptionsColumn.AllowEdit = true;
                
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

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                gridView1.Columns["Materia"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Clave"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Grupo"].OptionsColumn.AllowEdit = true;
            }
            sClave = "";
            sMateria = "";
        }
               
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                gridView1.Columns["Materia"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Clave"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Grupo"].OptionsColumn.AllowEdit = false;    
            }          
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value is string)
                e.Value = ((string)e.Value).Trim();
        }      
    }
}
