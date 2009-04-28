using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HorarioMaster;
using System.IO;
using System.Data.OleDb;
using frmCaptura;

namespace frmCaptura
{
    public partial class DGVMaster : UserControl
    {
        public DGVMaster()
        {
            InitializeComponent();
        }
       
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();
            
        DataGridViewComboBoxColumn Area = new DataGridViewComboBoxColumn();

        private void Binding1_PositionChanged(Object sender, EventArgs e)
        {
            //dataGridView1.CurrentRow.Cells.
            this.da.Update((DataTable)Binding1.DataSource);            
        }
        
        public void Fill_DGV(string sSql)
        {
            string cnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + PathDataBase;
            da = new OleDbDataAdapter(sSql, cnn);
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            dataGridView1.DataSource = Binding1;            
            dataGridView1.Refresh();
            
       }
        public void Fill_ComboboxColumn(string sFields, int nDGVIndex)
        {
            DataGridViewComboBoxColumn Temp = new DataGridViewComboBoxColumn();
            Temp.DataSource= tabla;
            Temp.DisplayMember = sFields;
            Temp.ValueMember = sFields;
            Temp.DataPropertyName = sFields;
            Temp.HeaderText = sFields;
            Temp.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[sFields].Visible = false;
            dataGridView1.Columns.Insert(nDGVIndex, Temp);
        }

        public void Fill_ComboboxColumnDefined(string sFields, int nDGVIndex)
        {
            DataGridViewComboBoxColumn Temp = new DataGridViewComboBoxColumn();
            //Temp.DataSource = tabla;
            //Temp.DisplayMember = sFields;
            //Temp.ValueMember = sFields;
            //Temp.Items.Clear();
            Temp.Items.Add("Matutino");
            Temp.Items.Add("Vespertino");
            Temp.HeaderText = "Turno          ";
            Temp.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[sFields].Visible = false;
            dataGridView1.Columns.Insert(nDGVIndex, Temp);
        }

        public void Fill_ButtonColumn(string sFields, int nDGVIndex)
        {
            DataGridViewButtonColumn Temp = new DataGridViewButtonColumn();
            Temp.Text = sFields;
            //Temp.DataGridView.
            
          //  dataGridView1.Columns.Insert(nDGVIndex, Temp);
        }

        //void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{

        //    if (e.Control is Button)
        //    {

        //        Button btn = e.Control as Button;

        //        btn.Click -= new EventHandler(btn_Click);

        //        btn.Click += new EventHandler(btn_Click);

        //    }

        //}
        //void btn_Click(object sender, EventArgs e)
        //{

        //    int col = this.dataGridView1.CurrentCell.ColumnIndex;

        //    int row = this.dataGridView1.CurrentCell.RowIndex;

        //    MessageBox.Show("Button in Cell[" +

        //        col.ToString() + "," +

        //        row.ToString() + "] has been clicked");

        //}

        
        
      

        private void DGVMaster_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //int i;
            //for (i = 0; i < dataGridView1.Rows.Count-1; i++)
            //{
            //   // if (dataGridView1.CurrentRow.Cells[i].ToString()==null)
            //   // {
            //   //     MessageBox.Show("No Deben De Existir Campos Vacios");
            //   //     dataGridView1.Rows[e.RowIndex].ErrorText = "No Deben De Existir Campos Vacios";
            //   //     e.Cancel = true;
            //   // }
            //}
        }


        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void eraseRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.SelectedRows[0].Index != this.dataGridView1.SelectedRows.Count - 1)
            {
                this.dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                this.da.Update((DataTable)Binding1.DataSource);
                dataGridView1.Refresh();
            }
       }
    }
}
