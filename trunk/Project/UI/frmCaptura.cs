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
        private GridMasterControl GridEspecialidad = new GridMasterControl();
        private GridMasterControl GridGrupos = new GridMasterControl();
        private GridMasterControl GridMaterias = new GridMasterControl();
        private GridMasterControl GridPersonal = new GridMasterControl();
        private GridMasterControl GridMaestroMaterias = new GridMasterControl();

        #endregion

        #region Fill_Grid's
        private void frmCaptura1_Load(object sender, EventArgs e)
        {
            //Grid Especialidad
            GridEspecialidad.Parent = splitContainerControl1.Panel1;
            GridEspecialidad.Dock = DockStyle.Fill;
            GridEspecialidad.FillGridMaster("Select Nombre,Plan,Materia,Periodos,Modalidad,Area From Especialidad", "ESPECIALIDAD","Especialidad,Plan de Estudios,No. Materia,Periodos,Modalidad,Area");
            GridEspecialidad.AddComboBoxColumn("Bachillerato Tecnologico", "Modalidad");
            GridEspecialidad.AddComboBoxColumn("Fisico-matematico,Economico-Administrativas,Quimico-Biologica","Area");
            //Grid Grupos
            GridGrupos.Parent = splitContainerControl2.Panel1;
            GridGrupos.Dock = DockStyle.Fill;
            GridGrupos.FillGridMaster("Select Especialidad,Semestre,Grupo,SG,Turno From Grupos", "GRUPOS","");
            GridGrupos.AddComboBoxColumn("Select Nombre From Especialidad", "Especialidad", "Nombre");
            GridGrupos.AddComboBoxColumn("MATUTINO,VESPERTINO", "Turno");
            //Grid Materias
            GridMaterias.Parent = splitContainerControl2.Panel2;
            GridMaterias.Dock = DockStyle.Fill;
            GridMaterias.FillGridMaster("Select Nombre,Clave,HT,HP,HC From Materias", "MATERIAS","");
            //Grid Personal
            GridPersonal.Parent = splitContainerControl3.Panel1;
            GridPersonal.Dock = DockStyle.Fill;
            GridPersonal.FillGridMaster("Select ClaveMaestro,Numero,NumeroTarjeta,Nombre,RFC,CURP,Sexo,Direccion,Colonia,CP,Localidad,Telefono,Celular,Email,Un,Sub,Catego,HS,MOV,Puesto,Perfil,INGGF,INGSEP,INGDGETI,Nombramiento,Actividad,Nivel,Descarga,NivelMaxEstudios,Observaciones From Personal", "PERSONAL", "");
            GridPersonal.AddlookUpColumn("Select Plaza,Maestro From Plaza", "Plaza", "Plaza");
            GridPersonal.AddComboBoxColumn("Masculino,Femenino", "Sexo");
            GridPersonal.AddComboBoxColumn("0,1,2,3,4,5,6,7,8,9,10", "Descarga");
            GridPersonal.AddComboBoxColumn("Sin Estudios,Primaria,Carrera Comercial,Carrera Tecnica,Secundaria,Bachillerato,Normal,Normal Superior,Licenciatura,Maestria,Doctorado,Tecnico Superior,Licenciatura Tecnica", "NivelMaxEstudios");
            GridPersonal.AddComboBoxColumn("Docente,Administrativo", "Actividad");
            GridPersonal.AddComboBoxColumn("Pasante,Titulado,Otro", "Nivel");
            GridPersonal.AddDateColumn("INGGF");
            GridPersonal.AddDateColumn("INGSEP");
            GridPersonal.AddDateColumn("INGDGETI");
            // Grid Asignar Materia
            GridMaestroMaterias.Parent = splitContainerControl3.Panel2;
            GridMaestroMaterias.Dock = DockStyle.Fill;
            GridMaestroMaterias.FillGridMaster("Select Nombre From Personal Where Puesto='DOCENTE'", "Asignar Materia", NewItemRowPosition.None,"");
            //GridMaestroMaterias.AddlookUpColumn("Materias","Maestro");
            GridMaestroMaterias.AddPopupColumn("", "Materias", "Maestro");
        }

        public void TabPageToFront()
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }
        #endregion
    }
}