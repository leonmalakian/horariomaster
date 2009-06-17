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
using System.Threading;

namespace HorarioMaster.Controls
{
    public partial class GridControlMaestroMateria : DevExpress.XtraEditors.XtraUserControl
    {
        public GridControlMaestroMateria()
        {
            InitializeComponent();
            GridControlPersonal.UpdateGrid2 += new GridControlPersonal.GridUpdate2(GridControlEspecialidad_UpdateGrid);
        }

        void GridControlEspecialidad_UpdateGrid()
        {
            //tabla.Clear();
            //FillGridView();
        }

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        static string sName = "";
        #endregion


        private void grdMaestroMateria_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        public void FillGridView()
        {
            tabla.Clear(); 
            DataBaseUtilities.OpenConnection(PathDataBase);
            da = DataBaseUtilities.FillDataAdapter("Select Nombre From Personal Where Actividad='Docente'");
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);           
            Binding1.DataSource = tabla;
            grdMaestroMateria.DataSource = Binding1;
            DataBaseUtilities.CloseConnection();
            AddPopupColumn("Materia", "Asignar Materia...");
            HeadersColumnsNames("Maestro");
            gridView1.Columns["Nombre"].OptionsColumn.ReadOnly = true;
            gridView1.BestFitColumns();
        }

        public void AddPopupColumn(string sColumnNameCreate,string sText)
        {   
            if (tabla.Columns["Materia"] != null) { return; }//tabla.Columns.Remove("Materia"); }
            RepositoryItemPopupContainerEdit temp = new RepositoryItemPopupContainerEdit();
            grdMaestroMateria.RepositoryItems.Add(temp);
            tabla.Columns.Add(sColumnNameCreate);
            gridView1.Columns.Add();
            grdMaestroMateria.MainView.BeginDataUpdate();
            gridView1.PopulateColumns();
            grdMaestroMateria.MainView.EndDataUpdate();
            temp.NullText = sText;
            (grdMaestroMateria.MainView as GridView).Columns.ColumnByFieldName(sColumnNameCreate).ColumnEdit = temp;
            gridView1.BestFitColumns();
            temp.Click += new EventHandler(temp_Click);
        }

        void temp_Click(object sender, EventArgs e)
        {
            frmGridMateria frmMateria = new frmGridMateria(sName);
            frmMateria.StartPosition = FormStartPosition.CenterScreen;
            frmMateria.ShowDialog();
            
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
            if (e.FocusedRowHandle >= 0)
            { sName = tabla.Rows[e.FocusedRowHandle].ItemArray[0].ToString(); }
        }

        private void grdMaestroMateria_Enter(object sender, EventArgs e)
        {
            FillGridView();
        }     
    }
}
