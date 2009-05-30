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
    public partial class GridControlGrupos : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlGrupos()
        {
            InitializeComponent();
            GridControlEspecialidad.UpdateGrid+=new GridControlEspecialidad.GridUpdate(GridControlEspecialidad_UpdateGrid);
        }

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        #endregion

        private void grdGrupos_Load(object sender, EventArgs e)
        {
            FillGridView();          
        }

        void GridControlEspecialidad_UpdateGrid()
        {
            FillGridView();
        }

        public void FillGridView()
        {
            tabla.Clear();
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select Especialidad,Semestre,Grupo,SG,Turno From Grupos");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdGrupos.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            AddComboBoxColumn("Select Nombre From Especialidad", "", "Especialidad", "Nombre");
            AddComboBoxColumn("", "MATUTINO,VESPERTINO", "Turno", "");
            AddComboBoxColumn("", "1,2,3,4,5,6", "Semestre", "");
            gridView1.Columns["SG"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["SG"].Visible = false;
            HeadersColumnsNames("Especialidad,Semestre,Grupo,Semestre/Grupo,Turno");
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
                (grdGrupos.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
                DataBaseUtilities.CloseConnection();
            }
            else
            {
                string[] ArrayItems = sItem.Split(',');
                for (int nIndex = 0; nIndex < ArrayItems.Length; nIndex++)
                {
                    Temp.Items.Add(ArrayItems[nIndex]);
                }
                (grdGrupos.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            }
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {            
            gridView1.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            CurrentRow.Row["SG"] = Convert.ToString(CurrentRow.Row["Semestre"]) + Convert.ToString(CurrentRow.Row["Grupo"]);
            for (int nColumn = 0; nColumn < CurrentRow.Row.ItemArray.Length; nColumn++)
            {
                if (CurrentRow.Row[nColumn].ToString() == "")
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns[nColumn].ToString() + " no debe estar vacio", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns[nColumn], "Este Campo no debe ser vacio");
                    return;
                }               
            }
            for (int nRow = 0; nRow < tabla.Rows.Count; nRow++)
            {
                if (CurrentRow.Row["SG"].ToString() == tabla.Rows[nRow].ItemArray[3].ToString() && CurrentRow.IsNew)
                {
                    e.Valid = false;
                    XtraMessageBox.Show("Ya existe este grupo en ese semestre", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["Grupo"], "No debe de haber grupos repetidos en el mismo semestre");
                    return;
                }
            }       
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

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.da.Update((DataTable)Binding1.DataSource);
            Binding1.DataSource = tabla;
            grdGrupos.DataSource = Binding1;
            gridView1.BestFitColumns();
        }

        private void gridView1_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                cmnuGrupos.Show(view.GridControl, e.Point);
            }
        }

        private void cmnuItemBorrar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas seguro que deseas borrar este registro?", "Borrar Registro", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                this.da.Update((DataTable)Binding1.DataSource);
                gridView1.BestFitColumns();
            }
        }

        private void gridView1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            //FillGridView();
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }       
    }
}
