using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HorarioMaster;
using System.IO;

namespace frmCaptura
{
    public partial class DGVMaster : UserControl
    {
        public DGVMaster()
        {
            InitializeComponent();
        }
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";

        private void DGVMaster_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            dataGridView1 = DataBaseUtilities.FillDataGridViewX("Select * From Plaza", dataGridView1, "Plaza");
            DataGridViewComboBoxColumn i = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn j = new DataGridViewComboBoxColumn();
            i.Items.Add("Bachillerato Tecnologico");
            j.Items.Add("Fisico,Matematicas");
            j.Items.Add("Econimico,Administrativas");
            j.Items.Add("Quimico,Biologica");
            i.HeaderText = " Modalidad ";
            i.Width = 150;
            j.HeaderText = " Area ";
            j.Width = 150;
            dataGridView1.Columns.Add(i);
            dataGridView1.Columns.Add(j);
            DataBaseUtilities.CloseConnection();
        }
    }
}
