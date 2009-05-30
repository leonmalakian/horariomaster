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
    public partial class GridControlEspecialidad : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlEspecialidad()
        {
            InitializeComponent();           
        }
        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        public delegate void GridUpdate();
        public static event GridUpdate UpdateGrid;       
        #endregion

        private void grdEspecialidad_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select Nombre,Plan,Materia,Periodos,Modalidad,Area From Especialidad");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            grdEspecialidad.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            AddComboBoxColumn("Bachillerato Tecnologico", "Modalidad");
            AddComboBoxColumn("Fisico-matematico,Economico-Administrativas,Quimico-Biologica", "Area");
            HeadersColumnsNames();
            gridView1.BestFitColumns();           
        }

        public void AddComboBoxColumn(string sItem, string sColumnNameReplace)
        {
            RepositoryItemComboBox Temp = new RepositoryItemComboBox();
            Temp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            string[] ArrayItems = sItem.Split(',');
            for (int nIndex = 0; nIndex < ArrayItems.Length; nIndex++)
            {
               Temp.Items.Add(ArrayItems[nIndex]);
            }
            (grdEspecialidad.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;
            
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            gridView1.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            for (int nColumn = 0; nColumn < CurrentRow.Row.ItemArray.Length; nColumn++)
            {
                if (CurrentRow.Row[nColumn].ToString() == "")
                {
                    e.Valid = false;
                    XtraMessageBox.Show(gridView1.Columns[nColumn].ToString() + " no debe estar vacio", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns[nColumn], "Este Campo no debe ser vacio");
                    return;
                }
                if (gridView1.Columns[nColumn].Name == "colPeriodos"||gridView1.Columns[nColumn].Name == "colMateria")
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
                if (CurrentRow.Row[0].ToString() == tabla.Rows[nRow].ItemArray[0].ToString() && CurrentRow.IsNew)
                {
                    e.Valid = false;
                    XtraMessageBox.Show("Especialidad no debe estar Repetido", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetColumnError(gridView1.Columns["Nombre"], "Este Campo no debe estar Repetido");
                    return;
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

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            this.da.Update((DataTable)Binding1.DataSource);
            Binding1.DataSource = tabla;
            grdEspecialidad.DataSource = Binding1;
            gridView1.BestFitColumns();
            UpdateGrid();            
        }

        private void gridView1_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                cmnuEspecialidad.Show(view.GridControl, e.Point);
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

        private void HeadersColumnsNames()
        {           
            gridView1.Columns[0].Caption = "Especialidad";
            gridView1.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[1].Caption = "Plan de Estudios";
            gridView1.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[2].Caption = "Materia";
            gridView1.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[3].Caption = "Periodo";
            gridView1.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[4].Caption = "Modalidad";
            gridView1.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[5].Caption = "Area";
            gridView1.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; 
        }

        DevExpress.XtraGrid.Columns.GridColumn prevColumn = null;
        int prevRow = -1;

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (prevColumn != view.FocusedColumn || prevRow != view.FocusedRowHandle)
            {
                e.Cancel = true;
            }
            prevColumn = view.FocusedColumn;
            prevRow = view.FocusedRowHandle;
        }
    }    
}
