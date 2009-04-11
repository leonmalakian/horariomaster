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

namespace HorarioMaster
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
            Form childFormC = new frmCaptura();
            childFormC.TopLevel = false;
            childFormC.Parent = this.splitContainer1.Panel2;
            childFormC.Height = this.splitContainer1.Panel2.Height;
            childFormC.Width = this.splitContainer1.Panel2.Width;
            childFormC.Dock = DockStyle.Fill;
            childFormC.Show();
            
        }

        private void horarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmHorario();
            childForm.TopLevel = false;
            childForm.Parent = this.splitContainer1.Panel2;
            childForm.Height = this.splitContainer1.Panel2.Height;
            childForm.Width = this.splitContainer1.Panel2.Width;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            
            switch (e.Node.Name)
            {
                 case "NodeCaptura":
                    Form childFormC = new frmCaptura();
                    childFormC.TopLevel = false;
                    childFormC.Parent = this.splitContainer1.Panel2;
                    childFormC.Height = this.splitContainer1.Panel2.Height;
                    childFormC.Width = this.splitContainer1.Panel2.Width;
                    childFormC.Dock = DockStyle.Fill;
                    childFormC.Show();
                    //if(e.Node.Name = "NodeHorario")
                    break;
                case "NodeHorario":
                    Form childForm = new frmHorario();
                    childForm.TopLevel = false;
                    childForm.Parent = this.splitContainer1.Panel2;
                    childForm.Height = this.splitContainer1.Panel2.Height;
                    childForm.Width = this.splitContainer1.Panel2.Width;
                    childForm.Dock = DockStyle.Fill;
                    childForm.Show();
                    break;
            }
        }

        
       
    }
}
