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

        #region Global's
        private GridMasterControl Grid1 = new GridMasterControl();
        private GridMasterControl Grid2 = new GridMasterControl();
        private GridMasterControl Grid3 = new GridMasterControl();
        #endregion

        #region NavBar

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmPortada Portada = new frmPortada();
            Portada.TopLevel = false;
            Portada.Parent = this.splitContainerControl1.Panel2;
            Portada.Dock = DockStyle.Fill;
            Portada.Enabled = false;
            Portada.ControlBox = false;
            Portada.Show();
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
                            CloseForms();
                            frmHorario Horario = new frmHorario();
                            Horario.TopLevel = false;
                            Horario.Parent = this.splitContainerControl1.Panel2;
                            Horario.Dock = DockStyle.Fill;
                            Horario.ControlBox = false;
                            Horario.Show();
                            break;
                        case "Maestros":
                            XtraMessageBox.Show(e.Link.Caption);
                            break;                    
                    }
                    break;
                
                case "navBarAltas":
                    CloseForms();
                    frmCaptura Captura = new frmCaptura();
                    switch (e.Link.Caption)
                    {
                            
                        case "Especialidad":
                            Captura.TopLevel = false;
                            Captura.Parent = this.splitContainerControl1.Panel2;
                            Captura.Dock = DockStyle.Fill;
                            Captura.ControlBox = false;
                            Captura.Show();
                            break;
                        case "Grupos":
                            Captura.TopLevel = false;
                            Captura.Parent = this.splitContainerControl1.Panel2;
                            Captura.Dock = DockStyle.Fill;
                            Captura.ControlBox = false;
                            Captura.Show();
                            break;
                        case "Materias":
                            Captura.TopLevel = false;
                            Captura.Parent = this.splitContainerControl1.Panel2;
                            Captura.Dock = DockStyle.Fill;
                            Captura.ControlBox = false;
                            Captura.Show();
                            break;
                        case "Personal":
                            Captura.TopLevel = false;
                            Captura.Parent = this.splitContainerControl1.Panel2;
                            Captura.Dock = DockStyle.Fill;
                            Captura.ControlBox = false;
                            Captura.TabPageToFront();
                            Captura.Show();
                            break;
                        case "Asignar Materias":
                            Captura.TopLevel = false;
                            Captura.Parent = this.splitContainerControl1.Panel2;
                            Captura.Dock = DockStyle.Fill;
                            Captura.ControlBox = false;
                            Captura.TabPageToFront();
                            Captura.Show();
                            break;
                    }
                    break;         
            }
        }
        #endregion

        #region Eventos_Menu
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form DPlantel = new frmDatosPlantel();
            DPlantel.StartPosition = FormStartPosition.CenterScreen;
            DPlantel.ShowDialog();
        }

        private void CloseForms()
        {
            List<Form> ListForms = new List<Form>();
                foreach (Form oForma in Application.OpenForms)
                {
                    if (oForma.GetType() != typeof(frmPrincipal) && oForma.GetType() != typeof(DevExpress.XtraBars.Forms.SubMenuControlForm))
                        ListForms.Add(oForma);
                }
            
            foreach (Form OpenForms in ListForms)
            {
                OpenForms.Close();
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AComplementarias AC = new AComplementarias();
            AC.StartPosition = FormStartPosition.CenterScreen;
            AC.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmHorario Horario = new frmHorario();
            Horario.TopLevel = false;
            Horario.Parent = this.splitContainerControl1.Panel2;
            Horario.Dock = DockStyle.Fill;
            Horario.ControlBox = false;
            Horario.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmCaptura Captura = new frmCaptura();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmCaptura Captura = new frmCaptura();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmCaptura Captura = new frmCaptura();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmCaptura Captura = new frmCaptura();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.TabPageToFront();
            Captura.Show();
        }
        #endregion

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmHorario Horario = new frmHorario();
            Horario.TopLevel = false;
            Horario.Parent = this.splitContainerControl1.Panel2;
            Horario.Dock = DockStyle.Fill;
            Horario.ControlBox = false;
            Horario.Show();
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForms();
            frmCaptura Captura = new frmCaptura();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.TabPageToFront();
            Captura.Show();
        }
    }
}