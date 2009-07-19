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
using DevExpress.LookAndFeel;
using HorarioMaster.Controls;
using DevExpress.XtraEditors.Controls;

namespace HorarioMaster.UI
{
    public partial class frmPrincipal : DevExpress.XtraEditors.XtraForm
    {
        public frmPrincipal()
        {
            InitializeComponent();            
        }

        #region Global's
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private int x = 0;
        #endregion

        #region NavBar

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmSkins.EnviarTema += new frmSkins.CambiarSkin(frmSkins_EnviarTema);           
            frmSkins_EnviarTema(Properties.Settings.Default.LookandFeel);            
          
            barBtnHide.SuperTip = new DevExpress.Utils.SuperToolTip();            
            barBtnSalir.SuperTip = new DevExpress.Utils.SuperToolTip();
            barBtnHide.SuperTip.Items.Add("Esconder Menu");            
            barBtnSalir.SuperTip.Items.Add("Salir del Programa");

            frmPortada Portada = new frmPortada();
            Portada.TopLevel = false;
            Portada.Parent = this.splitContainerControl1.Panel2;
            Portada.Dock = DockStyle.Top;
            Portada.Enabled = false;
            Portada.ControlBox = false;
            Portada.Show();
        }

        void frmSkins_EnviarTema(string sTema)
        {            
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(sTema);
            navBarControl1.LookAndFeel.SetSkinStyle(sTema);
            UserLookAndFeel temp = new UserLookAndFeel(navBarControl1);
            this.LookAndFeel.Assign(temp);
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
                    //Portada.Enabled = false;
                    Portada.ControlBox = false;
                    Portada.Show();
                    break;
                case "navBarReportes":
                    switch (e.Link.Caption)
                    {
                        case "Grupos":                            
                            frmParametersGroups Parameters = new frmParametersGroups();
                            Parameters.ShowDialog();
                            break;
                        case "Maestros":
                            //frmReportGeneral ReportGeneral = new frmReportGeneral();
                            //ReportGeneral.ShowDialog();
                            break;
                        case "General":
                            frmReportGeneral ReportGeneral = new frmReportGeneral();
                            ReportGeneral.ShowDialog();
                            break;
                    }
                    break;

                case "navBarHorarios":
                    frmHorario Horario = new frmHorario();
                    switch (e.Link.Caption)
                    {
                        case "Grupos":
                            CloseForms();
                            Horario.TopLevel = false;
                            Horario.Parent = this.splitContainerControl1.Panel2;
                            Horario.Dock = DockStyle.Fill;
                            Horario.ControlBox = false;
                            if (Horario.InicializeSchedule("Grupo"))
                            { Horario.Show(); }
                            else
                            {
                                frmPortada Portada1 = new frmPortada();
                                Portada1.TopLevel = false;
                                Portada1.Parent = this.splitContainerControl1.Panel2;
                                Portada1.Dock = DockStyle.Fill;
                                Portada1.Enabled = false;
                                Portada1.ControlBox = false;
                                Portada1.Show();
                            }                
                            break;
                        case "Maestros":
                            CloseForms();
                            Horario.TopLevel = false;
                            Horario.Parent = this.splitContainerControl1.Panel2;
                            Horario.Dock = DockStyle.Fill;
                            Horario.ControlBox = false;
                            if (Horario.InicializeSchedule("Maestro"))
                            { Horario.Show(); }
                            else
                            {
                                frmPortada Portada2 = new frmPortada();
                                Portada2.TopLevel = false;
                                Portada2.Parent = this.splitContainerControl1.Panel2;
                                Portada2.Dock = DockStyle.Fill;
                                Portada2.Enabled = false;
                                Portada2.ControlBox = false;
                                Portada2.Show();
                            }    
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
        private void bBtnDPlantel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void bBtnAComplementarias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAComplementarias AC = new frmAComplementarias();
            AC.StartPosition = FormStartPosition.CenterScreen;
            AC.ShowDialog();
        }

        private void bBtnEspecialidad_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaptura Captura = new frmCaptura();
            CloseForms();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void bBtnGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaptura Captura = new frmCaptura();
            CloseForms();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void bBtnMaterias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaptura Captura = new frmCaptura();
            CloseForms();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void bBtnPersonal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaptura Captura = new frmCaptura();
            CloseForms();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.TabPageToFront();
            Captura.Show();
        }

        private void bBtnHGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHorario Horario = new frmHorario();
            CloseForms();
            Horario.TopLevel = false;
            Horario.Parent = this.splitContainerControl1.Panel2;
            Horario.Dock = DockStyle.Fill;
            Horario.ControlBox = false;
            if (Horario.InicializeSchedule("Grupo"))
            { Horario.Show(); }
            else
            {
                frmPortada Portada = new frmPortada();
                Portada.TopLevel = false;
                Portada.Parent = this.splitContainerControl1.Panel2;
                Portada.Dock = DockStyle.Fill;
                Portada.Enabled = false;
                Portada.ControlBox = false;
                Portada.Show();
            }                
        }

        private void bBtnAsignarMaterias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void bBtnRGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmParametersGroups Parameters = new frmParametersGroups();
            Parameters.ShowDialog();
        }

        private void bBtnRGeneral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportGeneral ReportGeneral = new frmReportGeneral();
            ReportGeneral.ShowDialog();
        }

        private void bBtnHMaestros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHorario Horario = new frmHorario();
            CloseForms();
            Horario.TopLevel = false;
            Horario.Parent = this.splitContainerControl1.Panel2;
            Horario.Dock = DockStyle.Fill;
            Horario.ControlBox = false;
            if (Horario.InicializeSchedule("Maestro"))
            { Horario.Show(); }
            else
            {
                frmPortada Portada = new frmPortada();
                Portada.TopLevel = false;
                Portada.Parent = this.splitContainerControl1.Panel2;
                Portada.Dock = DockStyle.Fill;
                Portada.Enabled = false;
                Portada.ControlBox = false;
                Portada.Show();
            }    
        }

        private void bBtnRMaestros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bBtnIndice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bBtnContenido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bBtnQSomos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bBtnALogotipo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            openFileDialog1.Filter = "Mapas de bits (*.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Seleccionar Logotipo de Plantel";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataBaseUtilities.OpenConnection(PathDataBase);
                DataBaseUtilities.ExecuteNonSql("Update Plantel Set Imagen = '" + openFileDialog1.FileName + "'");
                DataBaseUtilities.CloseConnection();
                CloseForms();
                frmPortada Portada = new frmPortada();
                Portada.TopLevel = false;
                Portada.Parent = this.splitContainerControl1.Panel2;
                Portada.Enabled = false;
                Portada.ControlBox = false;
                Portada.Show();
            }
        }

        private void bBtnCTema_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSkins FormSkin = new frmSkins();
            FormSkin.StartPosition = FormStartPosition.CenterScreen;
            FormSkin.ShowDialog();
        }        

        private void barBtnHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barBtnHide.SuperTip = new DevExpress.Utils.SuperToolTip();
            barBtnHide.SuperTip.Items.Add("Mostrar Menu");
            if (splitContainerControl1.Panel1.Visible && x==0)
            {
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                x = 1;
                //splitContainerControl1.FixedPanel = SplitFixedPanel.Panel2;
                //splitContainerControl1.FixedPanel = SplitFixedPanel.Panel1;
                //splitContainerControl1.Panel2.Controls[0].Size = splitContainerControl1.Panel2.Size;
                splitContainerControl1.Panel2.Controls[0].Enabled = true;
                splitContainerControl1.Panel2.Controls[0].Update(); ;
                ////splitContainerControl1.Panel2.Controls[0].Show();
                //splitContainerControl1.Panel2.Controls[0].Height= splitContainerControl1.Panel2.Height;
                //splitContainerControl1.Panel2.Controls[0].Width = splitContainerControl1.Panel2.Width;
                //splitContainerControl1.Panel2.Controls[0].Parent = splitContainerControl1.Panel1;
                //splitContainerControl1.Panel1.Controls[1].Parent = splitContainerControl1.Panel2;

            }
            else
            {
                barBtnHide.SuperTip = new DevExpress.Utils.SuperToolTip();
                barBtnHide.SuperTip.Items.Add("Esconder Menu");
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                x = 0;
            }

        }

        private void barBtnHorario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHorario Horario = new frmHorario();
            CloseForms();
            Horario.TopLevel = false;
            Horario.Parent = this.splitContainerControl1.Panel2;
            Horario.Dock = DockStyle.Fill;
            Horario.InicializeSchedule("Grupo");
            Horario.ControlBox = false;
            Horario.Show();
        }

        private void barBtnCaptura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaptura Captura = new frmCaptura();
            CloseForms();
            Captura.TopLevel = false;
            Captura.Parent = this.splitContainerControl1.Panel2;
            Captura.Dock = DockStyle.Fill;
            Captura.ControlBox = false;
            Captura.Show();
        }

        private void barBtnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion                      

        private void barBtnCTema_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSkins FormSkin = new frmSkins();
            FormSkin.StartPosition = FormStartPosition.CenterScreen;
            FormSkin.ShowDialog();
        }

        private void splitContainerControl1_SplitterMoved(object sender, EventArgs e)
        {
            splitContainerControl1.Panel2.Controls[0].Size = splitContainerControl1.Panel2.Size;

        }
    }
}