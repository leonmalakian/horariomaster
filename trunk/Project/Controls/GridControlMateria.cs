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
    public partial class GridControlMateria : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlMateria()
        {
            InitializeComponent();
        }

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        #endregion


        private void grdMateria_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select Nombre,Clave,HT,HP,HC From Materias");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdMateria.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            AddComboBoxColumn("", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40", "HT", "");
            AddComboBoxColumn("", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40", "HP", "");
            gridView1.Columns["HC"].Visible = false;
            HeadersColumnsNames("Nombre,Clave,Horas Teoricas,Horas Practicas");
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
                (grdMateria.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            }
            else
            {
                string[] ArrayItems = sItem.Split(',');
                for (int nIndex = 0; nIndex < ArrayItems.Length; nIndex++)
                {
                    Temp.Items.Add(ArrayItems[nIndex]);
                }
                (grdMateria.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            }
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

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            gridView1.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            CurrentRow.Row["HC"] = Convert.ToInt32(CurrentRow.Row["HT"]) + Convert.ToInt32(CurrentRow.Row["HP"]);
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
                if (CurrentRow.Row["Clave"].ToString() == tabla.Rows[nRow].ItemArray[1].ToString() && CurrentRow.IsNew)
                {
                    e.Valid = false;
                    XtraMessageBox.Show("Ya existe esta clave", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["Clave"], "No debe de haber claves repetidas");
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
            grdMateria.DataSource = Binding1;
            gridView1.BestFitColumns();
        }

        private void gridView1_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                cmnuMaterias.Show(view.GridControl, e.Point);
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

    }
}
