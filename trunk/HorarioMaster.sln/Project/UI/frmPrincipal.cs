using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using HorarioMaster.UI;
using System.Windows.Forms;

namespace HorarioMaster
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private Form Primera = new Portada();
        private Form AltasModificaciones = new frmCaptura();
        private Form CrearHorario = new frmHorario();
        private Form Reportes = new Reportes();

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
            Primera.TopLevel = false;
            Primera.Parent = this.splitContainer1.Panel2;
            Primera.Dock = DockStyle.Fill;
            Primera.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel1Collapsed == true)
            {
                this.splitContainer1.Panel1Collapsed = false;
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = true;
            }
        }

        private void datosPlantelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form plantel = new DPlantel();
            //plantel.TopLevel = false;
            //plantel.Parent = this.splitContainer1.Panel2;
            plantel.Show();
        }

        private void actividadesComplementariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AComplement = new AComplementarias();
            AComplement.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "tNodeAltasModificaciones":
                    Primera.Close();
                    AltasModificaciones.TopLevel = false;
                    AltasModificaciones.Parent = this.splitContainer1.Panel2;
                    AltasModificaciones.Height = this.splitContainer1.Panel2.Height;
                    AltasModificaciones.Width = this.splitContainer1.Panel2.Width;
                    AltasModificaciones.Dock = DockStyle.Fill;
                    AltasModificaciones.Show();
                break;
                case "tNodeCrearHorario":
                    AltasModificaciones.Close();
                    CrearHorario.TopLevel = false;
                    CrearHorario.Parent = this.splitContainer1.Panel2;
                    CrearHorario.Height = this.splitContainer1.Panel2.Height;
                    CrearHorario.Width = this.splitContainer1.Panel2.Width;
                    CrearHorario.Dock = DockStyle.Fill;
                    CrearHorario.Show();
                break;
                case "tNodeReportes":
                    CrearHorario.Close();
                    Reportes.TopLevel = false;
                    Reportes.Parent = this.splitContainer1.Panel2;
                    Reportes.Height = this.splitContainer1.Panel2.Height;
                    Reportes.Width = this.splitContainer1.Panel2.Width;
                    Reportes.Dock = DockStyle.Fill;
                    Reportes.Show();
                break;
                
            }
        }

        private void altasYModificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Primera.Close();
            AltasModificaciones.TopLevel = false;
            AltasModificaciones.Parent = this.splitContainer1.Panel2;
            AltasModificaciones.Height = this.splitContainer1.Panel2.Height;
            AltasModificaciones.Width = this.splitContainer1.Panel2.Width;
            AltasModificaciones.Dock = DockStyle.Fill;
            AltasModificaciones.Show();
        }

        
    }
}
