using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HorarioMaster;
using System.IO;
using HorarioMaster.Controls;

namespace HorarioMaster.UI
{
    public partial class frmPrincipal : DevExpress.XtraEditors.XtraForm
    {
        public frmPrincipal()
        {
            InitializeComponent();           
        }

        private XtraDGVMaster Grid1 = new XtraDGVMaster();
        private XtraDGVMaster Grid2 = new XtraDGVMaster();
        private XtraDGVMaster Grid3 = new XtraDGVMaster();

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //CloseForms();
            //frmPortada Portada = new frmPortada(); 
            //Portada.TopLevel = false;
            //Portada.Parent = this.splitContainerControl1.Panel2;
            //Portada.Dock = DockStyle.Fill;
            //Portada.Enabled = false;
            //Portada.ControlBox = false;
            //Portada.Show();
        }
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form DPlantel = new frmDatosPlantel();
            DPlantel.StartPosition = FormStartPosition.CenterScreen;
            DPlantel.ShowDialog();
        }
        
        void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {        
            switch(e.Link.Group.Name)
            {
                case "navBarInicio":
                    CloseForms();
                    frmPortada Portada = new frmPortada();
                    Portada.TopLevel = false;
                    Portada.Parent = this.splitContainerControl1.Panel2;
                    Portada.Dock = DockStyle.Fill;
                    Portada.Enabled = false;
                    Portada.ControlBox = false;
                    Portada.Show();
                    break;
                case "navBarReportes":
                    switch (e.Link.Caption)
                    {
                        case "Grupos":
                            XtraMessageBox.Show(e.Link.Caption);
                            break;
                        case "Maestros":
                            XtraMessageBox.Show(e.Link.Caption);
                            break;
                        case "General":
                            XtraMessageBox.Show(e.Link.Caption);
                            break;
                    }
                    break;

                case "navBarHorarios":
                    switch (e.Link.Caption)
                    {
                        case "Grupos":
                            XtraMessageBox.Show(e.Link.Caption);
                            break;
                        case "Maestros":
                            XtraMessageBox.Show(e.Link.Caption);
                            break;                    
                    }
                    break;
                
                case "navBarAltas":                    
                    switch (e.Link.Caption)
                    {
                        case "Especialidad":
                            CloseForms();
                            frmCaptura Captura = new frmCaptura();
                            Captura.TopLevel = false;
                            Captura.Parent = this.splitContainerControl1.Panel2;
                            Captura.Dock = DockStyle.Fill;
                            Captura.Enabled = false;
                            Captura.ControlBox = false;
                            Captura.Show();
                            break;
                        case "Grupos":
                            CloseForms();
                            frmCaptura Captura1 = new frmCaptura();
                            Captura1.TopLevel = false;
                            Captura1.Parent = this.splitContainerControl1.Panel2;
                            Captura1.Dock = DockStyle.Fill;
                            Captura1.Enabled = false;
                            Captura1.ControlBox = false;
                            Captura1.Show();
                            break;
                        case "Materias":
                            CloseForms();
                            frmCaptura Captura2 = new frmCaptura();
                            Captura2.TopLevel = false;
                            Captura2.Parent = this.splitContainerControl1.Panel2;
                            Captura2.Dock = DockStyle.Fill;
                            Captura2.Enabled = false;
                            Captura2.ControlBox = false;
                            Captura2.Show();
                            break;
                        case "Personal":                            
                            break;
                    }
                    break;         
            }            
        }

        private void AModificaciones_Paint(object sender, PaintEventArgs e)
        {
            //Grid1.Parent = 
            Grid1.Dock = DockStyle.Fill;
            Grid1.Fill_XtraDGV("Select Nombre,Plan,Materia,Periodos,Modalidad,Area From Especialidad");
            //Grid2.Parent = 
            //Grid2.Dock = DockStyle.Fill;
            //Grid2.Fill_XtraDGV("Select Especialidad,Semestre,Grupo,SG,Turno From Grupos");
            //Grid3.Parent = splitContainerControl2.Panel2;
            //Grid3.Dock = DockStyle.Fill;
            //Grid3.Fill_XtraDGV("Select Nombre,Clave,HT,HP,HC From Materias");
        }        

        private void barStaticItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmCaptura Captura = new frmCaptura();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.Enabled = false;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void CloseForms()
        {
            List<Form> ListForms = new List<Form>();
            if (Application.OpenForms.Count == 3)
            {
                foreach (Form oForma in Application.OpenForms)
                {
                    if (oForma.GetType() != typeof(frmPrincipal) && oForma.GetType() != typeof(DevExpress.XtraBars.Forms.SubMenuControlForm))
                        ListForms.Add(oForma);
                }
            }

            foreach (Form OpenForms in ListForms)
            {
                OpenForms.Close();
            }
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {            
            //if (navBarControl1.SelectedLink.Group== "navBarInicio")
            //{
            //    CloseForms();
            //    frmPortada Portada = new frmPortada();
            //    Portada.TopLevel = false;
            //    Portada.Parent = this.splitContainerControl1.Panel2;
            //    Portada.Dock = DockStyle.Fill;
            //    Portada.Enabled = false;
            //    Portada.ControlBox = false;
            //    Portada.Show();
            //}
        }

        void navBarControl1_GroupExpanded(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            
        }

        void navBarControl1_GroupCollapsed(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {            
        }

    }
}