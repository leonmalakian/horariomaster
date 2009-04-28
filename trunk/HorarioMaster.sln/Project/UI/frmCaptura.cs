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

        private DGVMaster Grid3 = new DGVMaster();

        private void frmCaptura_Load(object sender, EventArgs e)
        {
            DGVMaster Grid = new DGVMaster();
            DGVMaster Grid2 = new DGVMaster();
            //DGVMaster Grid3 = new DGVMaster();
            Grid.Parent = this.splitContainer1.Panel1;
            Grid2.Parent = this.splitContainer2.Panel1;
            Grid3.Parent = this.splitContainer2.Panel2;
            Grid.Dock = DockStyle.Fill;
            Grid2.Dock = DockStyle.Fill;
            Grid3.Dock = DockStyle.Fill;
            Grid.Fill_DGV("Select Nombre,Plan,Materia,Periodos,Modalidad,Area From Especialidad");
            Grid.Fill_ComboboxColumn("Modalidad", 4);
            Grid.Fill_ComboboxColumn("Area", 5);
            Grid2.Fill_DGV("Select Especialidad,Semestre,Grupo,SG,Turno From Grupos");
            Grid2.Fill_ComboboxColumn("Especialidad", 0);
            Grid2.Fill_ComboboxColumnDefined("Turno", 4);
            Grid3.Fill_DGV("Select Nombre,Clave,HT,HP,HC From Materias");
            Grid3.Fill_ButtonColumn("Especialidad", 1);
            
            //Grid3.Fill_ComboboxColumnDefined("Turno", 4);
         }
    }
}
