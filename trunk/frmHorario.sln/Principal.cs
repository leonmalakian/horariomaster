using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using captura;

namespace frmCaptura
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private static Form childForm = new frmCaptura();

        private void capturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmCaptura();
            childForm.TopLevel = false;
            childForm.Parent = this.splitContainer1.Panel2;
            childForm.Height = this.splitContainer1.Panel2.Height;
            childForm.Width = this.splitContainer1.Panel2.Width;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
            
        }
    }
}
