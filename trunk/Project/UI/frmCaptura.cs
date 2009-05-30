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
            //GridPersonal.FillGridMaster("Select Numero,NumeroTarjeta,Nombre,Sexo,RFC,CURP,Direccion,Colonia,CP,Localidad,Telefono,Celular,Email,INGGF,INGSEP,INGDGETI,Perfil,Puesto,Nombramiento,Descarga,NivelMaxEstudios,Actividad,Nivel,Sub,Catego,MOV,Un,HS From Personal", "PERSONAL");
            //GridPersonal.AddPopupColumn("Select Maestro,Plaza From Plaza", "Plaza", "Plaza", "Numero,Numero de Tarjeta,Nombre,Sexo,RFC,CURP,Direccion,Colonia,CP,Localidad,Telefono de Casa,Telefono Celular,Correo Electronico,INGGF,INGSEP,INGDGETI,Perfil,Puesto,Nombramiento,Descarga,Nivel Maximo de Estudios,Actividad,Nivel,Subcategoria,Clave,Movimiento,Unidad,Horas,Plaza", "Maestro");
            //GridPersonal.AddComboBoxColumn("Masculino,Femenino", "Sexo");
            //GridPersonal.AddComboBoxColumn("0,1,2,3,4,5,6,7,8,9,10", "Descarga");
            //GridPersonal.AddComboBoxColumn("Sin Estudios,Primaria,Carrera Comercial,Carrera Tecnica,Secundaria,Bachillerato,Normal,Normal Superior,Licenciatura,Maestria,Doctorado,Tecnico Superior,Licenciatura Tecnica", "NivelMaxEstudios");
            //GridPersonal.AddComboBoxColumn("Docente,Administrativo", "Actividad");
            //GridPersonal.AddComboBoxColumn("Pasante,Titulado,Otro", "Nivel");
            //GridPersonal.AddComboBoxColumn("03,27", "Sub");
            //GridPersonal.AddComboBoxColumn("Select Clave From Clave", "Catego", "Clave");
            //GridPersonal.AddComboBoxColumn("10,25,95", "MOV");
            //GridPersonal.AddDateColumn("INGGF");
            //GridPersonal.AddDateColumn("INGSEP");
            //GridPersonal.AddDateColumn("INGDGETI");
            //GridPersonal.Leave += new EventHandler(GridPersonal_Leave);
        }      

        private void FillgrdMaestroMateria()
        {
            GridMaestroMaterias.Parent = splitContainerControl3.Panel2;
            GridMaestroMaterias.Dock = DockStyle.Fill;
            //GridMaestroMaterias.FillGridMaster("Select Nombre From Personal Where Puesto='DOCENTE'", "Asignar Materia", NewItemRowPosition.None, "");
            //GridMaestroMaterias.AddPopupColumn("", "Materias", "Maestro", "", "Clave,Grupo");
        }
        #endregion   
    }
}