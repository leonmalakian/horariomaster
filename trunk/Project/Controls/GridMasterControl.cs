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


namespace HorarioMaster.Controls
{
    public partial class GridMasterControl : DevExpress.XtraEditors.XtraUserControl
    {

        public GridMasterControl()
        {
            InitializeComponent();
        }
        
        #region Global_Items
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
        private static string ColumnType = "";
        private static string ColumnPopUp = "";
        string Sql = "";
        string Field = "";
        string sName1 = "";
        string RowName = "";
        
        #endregion

        #region Save_Data
        private void Binding1_PositionChanged(Object sender, EventArgs e)
        {
           this.da.Update((DataTable)Binding1.DataSource);
        }
        #endregion

        # region Fill_Grid
        public void FillGridMaster(string sSql,string Gname,bool Wid)
        {
            string cnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + PathDataBase;
            da = new OleDbDataAdapter(sSql, cnn);
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            gridControl1.DataSource = Binding1;
            labelControl1.Text = Gname;
            gridView1.OptionsView.ColumnAutoWidth = Wid;
        }

        public void AddComboBoxColumn(string sItems, string sColumnNameReplace)
        {
            AddComboBoxColumn("", sItems, sColumnNameReplace, "");
        }

        public void AddComboBoxColumn(string sSql, string sColumnNameReplace, string sFieldChargeComboBox)
        {
            AddComboBoxColumn(sSql, "", sColumnNameReplace, sFieldChargeComboBox);
        }

        public void AddComboBoxColumn(string sSql, string sItem, string sColumnNameReplace, string sFieldChargeComboBox)
        {
            RepositoryItemComboBox Temp = new RepositoryItemComboBox();
            
            if (sSql != "" )
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                Temp = DataBaseUtilities.FillRepositoryItemComboBox(sSql, sFieldChargeComboBox, Temp);
                (gridControl1.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;                
            }
            else
            {
                string[] ArrayItems = sItem.Split(',');
                for (int nIndex = 0; nIndex < ArrayItems.Length; nIndex++)
                {
                    Temp.Items.Add(ArrayItems[nIndex]);
                }
                (gridControl1.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = Temp;                    
            }
       }

        public void AddlookUpColumn(string sColumnNameReplace, string sNameValue)
        {
            AddlookUpColumn("", sColumnNameReplace, sNameValue);
        }

        public void AddlookUpColumn(string sSql, string sColumnNameCreate, string sHeader)
        {
            RepositoryItemPopupContainerEdit temp = new RepositoryItemPopupContainerEdit();
            gridControl1.RepositoryItems.Add(temp);
            tabla.Columns.Add(sColumnNameCreate);
            gridView1.Columns.Add();
            gridControl1.MainView.BeginDataUpdate();
            gridView1.PopulateColumns();
            gridControl1.MainView.EndDataUpdate();
            (gridControl1.MainView as GridView).Columns.ColumnByFieldName(sColumnNameCreate).ColumnEdit = temp;
            gridView1.Columns[sColumnNameCreate].ColumnEdit.NullText = sColumnNameCreate;
            Sql = sSql;
            Field = sColumnNameCreate;
            sName1 = sHeader;
            temp.ButtonPressed += new ButtonPressedEventHandler(temp_ButtonPressed);
            temp.EditValueChanged += new EventHandler(temp_EditValueChanged);
        }

        public void AddDateColumn(string sColumnNameReplace)
        {
            RepositoryItemDateEdit temp = new RepositoryItemDateEdit();
            gridControl1.RepositoryItems.Add(temp);
            (gridControl1.MainView as GridView).Columns.ColumnByFieldName(sColumnNameReplace).ColumnEdit = temp;
           
        }      

        void temp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.Columns["Plaza"].OptionsColumn.Reset();
        }

        void temp_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            frmDGVMaster temp = new frmDGVMaster();
            temp.StartPosition = FormStartPosition.CenterScreen;
            if (Sql != "")
            {
                temp.CaptureParams(Sql, Field.ToUpper());
                temp.ShowDialog();
            }
            else
            {
               temp.CaptureParams("Select Maestro,Materia,Clave,Grupo From MaestroMateria Where Maestro = '"+RowName+"'","Materias Asignadas");
               temp.ShowDialog();
            }
         }

        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {            
            this.da.Update((DataTable)Binding1.DataSource);
            if (sName1 == "Maestro")
            { RowName = tabla.Rows[Binding1.Position].ItemArray[0].ToString(); }
        }

        private void gridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {

            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                contextMenuStrip1.Show(view.GridControl, e.Point);
            }
        }
        #endregion

        #region Grid_Events
        private void borrarRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas seguro que deseas borrar este registro?", "Borrar Registro", MessageBoxButtons.YesNo)!= DialogResult.No)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                this.da.Update((DataTable)Binding1.DataSource);
            }
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            //if (ColumnPopUp != "PopupContainerEdit")
            //{
            //    if (e.Value.ToString() == "")
            //    {
            //        e.Valid = false;
            //        e.ErrorText = "Este campo no debe estar vacio";
            //    }             
            //    if (ColumnType == "Int32")
            //    {
            //        if (!IsNumeric(e.Value.ToString()))
            //        {
            //            e.Valid = false;
            //            e.ErrorText = "Este campo es numerico";
            //        }
            //    }
            //}
        }

        private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Error de Captura";
            //e.ErrorText = "Campo Vacio";
            MessageBox.Show(e.ErrorText);
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            ColumnType =  gridView1.Columns[e.Column.FieldName].ColumnType.Name;
        }

        #endregion

      public static bool IsNumeric(object Cadena)
      {
      bool isNumber;
      double isItNumeric;
      isNumber = Double.TryParse(Convert.ToString(Cadena), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out isItNumeric);
      return isNumber;
      }

      private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
      {
          ColumnPopUp = e.RepositoryItem.EditorTypeName;
      }       
    }
}
