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
    public partial class GridControlAComplementarias : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlAComplementarias()
        {
            InitializeComponent();
        }

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();        
        #endregion

        private void grdAComplementarias_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From ActComp");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdAComplementarias.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            gridView1.Columns["Index"].Visible = false;
            HeadersColumnsNames("Index,Numero,Nombre");
            gridView1.BestFitColumns();
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
                cmnuAComplementarias.Show(view.GridControl, e.Point);
            }
        }

        private void cmnuItemBorrar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas seguro que deseas borrar este registro?", "Borrar Registro", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                this.da.Update((DataTable)Binding1.DataSource);
                tabla.Clear();
                DataBaseUtilities.OpenConnection(PathDataBase);
                da = DataBaseUtilities.FillDataAdapter("Select * From ActComp");
                OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
                this.da.Fill(tabla);
                Binding1.DataSource = tabla;
                grdAComplementarias.DataSource = Binding1;
                DataBaseUtilities.CloseConnection();
                gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
                gridView1.BestFitColumns();    
            }
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.da.Update((DataTable)Binding1.DataSource);
            Binding1.DataSource = tabla;
            grdAComplementarias.DataSource = Binding1;
            tabla.Clear();
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From ActComp");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdAComplementarias.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
            gridView1.BestFitColumns();            
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            gridView1.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            for (int nColumn = 0; nColumn < CurrentRow.Row.ItemArray.Length; nColumn++)
            {
                if (CurrentRow.Row[nColumn].ToString() == "" && nColumn != 0)
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

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value is string)
                e.Value = ((string)e.Value).Trim();
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                gridView1.Columns["Numero"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Nombre"].OptionsColumn.AllowEdit = false;
            } 
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                gridView1.Columns["Numero"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["Nombre"].OptionsColumn.AllowEdit = true;
            }
        }
    }
}
