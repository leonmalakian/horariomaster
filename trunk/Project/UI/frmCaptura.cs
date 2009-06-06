using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using HorarioMaster;
using System.IO;
using HorarioMaster.Controls;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace HorarioMaster.UI
{
    public partial class frmCaptura : DevExpress.XtraEditors.XtraForm
    {
        public frmCaptura()
        {
            InitializeComponent();            
        }
        
        #region Global's
        private GridControlEspecialidad GridEspecialidad = new GridControlEspecialidad();
        private GridControlMateria GridMaterias = new GridControlMateria();
        private GridControlPersonal GridPersonal = new GridControlPersonal();
        private GridControlMaestroMateria GridMaestroMaterias = new GridControlMaestroMateria();
        private GridControlGrupos GridGrupos = new GridControlGrupos();                
                
        #endregion

        #region Fill_Grid's
        private void frmCaptura1_Load(object sender, EventArgs e)
        {
            
            FillgrdEspecialidad();
            FillgrdGrupos();
            FillgrdMaterias();
            FillgrdPersonal();
            FillgrdMaestroMateria();
        }

        public void TabPageToFront()
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        private void FillgrdEspecialidad()
        {
            GridEspecialidad.Parent = splitContainerControl1.Panel1;
            GridEspecialidad.Dock = DockStyle.Fill;
        }
     
        private void FillgrdGrupos()
        {
            GridGrupos.Parent = splitContainerControl2.Panel1;
            GridGrupos.Dock = DockStyle.Fill;
      
        }

        private void FillgrdMaterias()
        {
            GridMaterias.Parent = splitContainerControl2.Panel2;
            GridMaterias.Dock = DockStyle.Fill;
        }

        private void FillgrdPersonal()
        {
            GridPersonal.Parent = splitContainerControl3.Panel1;
            GridPersonal.Dock = DockStyle.Fill;           
        }      

        private void FillgrdMaestroMateria()
        {
            GridMaestroMaterias.Parent = splitContainerControl3.Panel2;
            GridMaestroMaterias.Dock = DockStyle.Fill;            
        }
        #endregion   
    }
}