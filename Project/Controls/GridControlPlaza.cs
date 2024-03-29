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
    public partial class GridControlPlaza : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlPlaza(string sNamePersonal,int IndexClave)
        {
            sName = sNamePersonal;
            nIndexClave = IndexClave;
            InitializeComponent();
            GridControlPersonal.UpdateGrid2 += new GridControlPersonal.GridUpdate2(GridControlPersonal_UpdateGrid);
        }

        void GridControlPersonal_UpdateGrid()
        {         
            FillGridView();
        }        

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        static string sName = "";
        static int nIndexClave = -1;
        #endregion

        private void grdPlaza_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void FillGridView()
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From Plaza WHERE Maestro = '" + sName + "' AND IndexClave="+nIndexClave+"");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);          
            Binding1.DataSource = tabla;
            grdPlaza.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            gridView1.Columns["Maestro"].OptionsColumn.ReadOnly = true;
            AddComboBoxColumn("", "03,27", "Subcategoria", "");
            AddComboBoxColumn("", "10,25,95", "Mov", "");
            AddComboBoxColumn("", "27,99", "Unidad", "");
            AddComboBoxColumn("", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40", "Horas", "");
            HeadersColumnsNames("Clave Plaza,Maestro,Subcategoria,Unidad,Plaza,Movimiento,Horas,Index");
            gridView1.Columns["ClavePlaza"].Visible = false;
            gridView1.Columns["Maestro"].Visible = false;
            gridView1.Columns["IndexClave"].Visible = false;
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
                (grdPlaza.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            }
            else
            {
                string[] ArrayItems = sItem.Split(',');
                for (int nIndex = 0; nIndex < ArrayItems.Length; nIndex++)
                {
                    Temp.Items.Add(ArrayItems[nIndex]);
                }
                (grdPlaza.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            }
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
                cmnuPlazas.Show(view.GridControl, e.Point);
            }
        }

        private void cmnuItemBorrar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas seguro que deseas borrar este registro?", "Borrar Registro", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                this.da.Update((DataTable)Binding1.DataSource);
                Binding1.DataSource = tabla;
                grdPlaza.DataSource = Binding1;
                tabla.Clear();
                DataBaseUtilities.OpenConnection(PathDataBase);
                da = DataBaseUtilities.FillDataAdapter("Select * From Plaza WHERE Maestro = '" + sName + "' AND IndexClave=" + nIndexClave + "");
                OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
                this.da.Fill(tabla);
                Binding1.DataSource = tabla;
                grdPlaza.DataSource = Binding1;
                DataBaseUtilities.CloseConnection();
                gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
                gridView1.BestFitColumns();
            }
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.da.Update((DataTable)Binding1.DataSource);
            Binding1.DataSource = tabla;
            grdPlaza.DataSource = Binding1;
            tabla.Clear();
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select * From Plaza WHERE Maestro = '" + sName + "' AND IndexClave=" + nIndexClave + "");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdPlaza.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            gridView1.SelectRow(gridView1.SelectedRowsCount - 1);
            gridView1.BestFitColumns();
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "colMaestro")
            {
                e.DisplayText = sName;
            }
            if (e.Column.Name == "colIndexClave")
            {
                e.DisplayText = nIndexClave.ToString();
            }

        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "Maestro", sName);
            gridView1.SetRowCellValue(e.RowHandle, "IndexClave", nIndexClave);
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value is string)
                e.Value = ((string)e.Value).Trim();
        } 
    }
}
