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
    public partial class GridControlClave : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlClave(string Name)
        {
            sName = Name;
            InitializeComponent();
        }

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        static string sName = "";
        static int nClave = -1;
        #endregion     

        private void grdClave_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        public void FillGridView()
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From ClaveTabla WHERE Nombre = '" + sName + "'");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);            
            Binding1.DataSource = tabla;
            grdClave.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            AddPopupColumn("Plaza", "Asignar Plaza..."); 
            AddComboBoxColumn("Select Clave From Clave", "", "Clave", "Clave");
            HeadersColumnsNames("Index,Nombre,Clave");            
            gridView1.Columns["Nombre"].Visible = false;
            gridView1.Columns["Index"].Visible = false;
            gridView1.BestFitColumns();
        }

         public void AddComboBoxColumn(string sSql, string sItem, string sColumnNameReplace, string sFieldChargeComboBox)
        {
            RepositoryItemComboBox Temp = new RepositoryItemComboBox();
            Temp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
             DataBaseUtilities.OpenConnection(PathDataBase);
             Temp = DataBaseUtilities.FillRepositoryItemComboBox(sSql, sFieldChargeComboBox, Temp);
             (grdClave.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;                       
        }

         public void AddPopupColumn(string sColumnNameCreate, string sText)
        {
            RepositoryItemPopupContainerEdit temp = new RepositoryItemPopupContainerEdit();
            grdClave.RepositoryItems.Add(temp);
            tabla.Columns.Add(sColumnNameCreate);
            gridView1.Columns.Add();
            grdClave.MainView.BeginDataUpdate();
            gridView1.PopulateColumns();
            grdClave.MainView.EndDataUpdate();
            temp.NullText = sText;
            (grdClave.MainView as GridView).Columns.ColumnByFieldName(sColumnNameCreate).ColumnEdit = temp;
            gridView1.BestFitColumns();
            temp.Click += new EventHandler(temp_Click);
        }

        void temp_Click(object sender, EventArgs e)
        {           
            frmGridPlaza frmPlaza = new frmGridPlaza(sName,nClave);
            frmPlaza.StartPosition = FormStartPosition.CenterScreen;
            frmPlaza.ShowDialog();      
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            gridView1.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            for (int nColumn = 0; nColumn < CurrentRow.Row.ItemArray.Length; nColumn++)
            {
                if (CurrentRow.Row[nColumn].ToString() == "" && nColumn != 0 && nColumn != 3)
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
                cmnuClave.Show(view.GridControl, e.Point);
            }
        }

        private void cmnuItemBorrar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas seguro que deseas borrar este registro?", "Borrar Registro", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                this.da.Update((DataTable)Binding1.DataSource);
                Binding1.DataSource = tabla;
                grdClave.DataSource = Binding1;
                tabla.Clear();
                DataBaseUtilities.OpenConnection(PathDataBase);
                da = DataBaseUtilities.FillDataAdapter("Select * From ClaveTabla WHERE Nombre = '" + sName + "'");
                OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
                this.da.Fill(tabla);
                Binding1.DataSource = tabla;
                grdClave.DataSource = Binding1;
                DataBaseUtilities.CloseConnection();
                gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
                gridView1.BestFitColumns();
            }
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.da.Update((DataTable)Binding1.DataSource);
            Binding1.DataSource = tabla;
            grdClave.DataSource = Binding1;
            tabla.Clear();
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From ClaveTabla WHERE Nombre = '" + sName + "'");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdClave.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
            gridView1.BestFitColumns();
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "colNombre")
            {
                e.DisplayText = sName;
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "Nombre", sName);
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                nClave = Convert.ToInt32(tabla.Rows[e.FocusedRowHandle].ItemArray[0]);
                if (gridView1.Columns["Plaza"] != null)
                {
                    gridView1.Columns["Plaza"].OptionsColumn.AllowEdit = true;
                }
            }
            else
            {
                gridView1.Columns["Plaza"].OptionsColumn.AllowEdit = false;
            }
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value is string)
                e.Value = ((string)e.Value).Trim();
        } 
    }
}
