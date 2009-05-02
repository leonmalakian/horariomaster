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
    public partial class frmCaptura : DevExpress.XtraEditors.XtraForm
    {
        public frmCaptura()
        {
            InitializeComponent();
        }
        private XtraDGVMaster Grid1 = new XtraDGVMaster();
        private XtraDGVMaster Grid2 = new XtraDGVMaster();
        private XtraDGVMaster Grid3 = new XtraDGVMaster();

        private void frmCaptura_Load(object sender, EventArgs e)
        {
            Grid1.Parent = splitContainerControl1.Panel1;
            Grid1.Dock = DockStyle.Fill;
            Grid1.Fill_XtraDGV("Select Nombre,Plan,Materia,Periodos,Modalidad,Area From Especialidad");
            Grid2.Parent = splitContainerControl2.Panel1;
            Grid2.Dock = DockStyle.Fill;
            Grid2.Fill_XtraDGV("Select Especialidad,Semestre,Grupo,SG,Turno From Grupos");
            Grid3.Parent = splitContainerControl2.Panel2;
            Grid3.Dock = DockStyle.Fill;
            Grid3.Fill_XtraDGV("Select Nombre,Clave,HT,HP,HC From Materias");

        }
    }
}