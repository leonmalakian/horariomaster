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
using frmCaptura;

namespace HorarioMaster
{
    public partial class frmCaptura : Form
    {
        public frmCaptura()
        {
            InitializeComponent();
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";

        private void frmCaptura_Load(object sender, EventArgs e)
        {
            DGVMaster Grid = new DGVMaster();
            DGVMaster Grid1 = new DGVMaster();
            DGVMaster Grid2 = new DGVMaster();
            Grid.Parent = this.splitContainer1.Panel1;
            Grid1.Parent = this.splitContainer2.Panel1;
            Grid2.Parent = this.splitContainer2.Panel2;
            Grid.Dock = DockStyle.Fill;
            Grid1.Dock = DockStyle.Fill;
            Grid2.Dock = DockStyle.Fill;
            Grid.Show();
            Grid1.Show();
            Grid2.Show();

        }

        
    }
}
