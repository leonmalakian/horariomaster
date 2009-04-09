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

namespace frmCaptura
{
    public partial class frmCaptura : Form
    {
        public frmCaptura()
        {
            InitializeComponent();
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";

        private void frmCaptura_Load(object sender, EventArgs e)
        {
            string[] Headers = new string[] { "Nombre", "Plan de Estudios", "Numero de Materia", "Periodos" };
            DataBaseUtilities.AbrirConnexion(PathDataBase);
            Especialidad = DataBaseUtilities.FillDataGridView("Select Nombre,Plan,Materia,Periodos From Especialidad", Especialidad, "Especialidad", Headers);
            DataGridViewComboBoxColumn i = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn j = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn K = new DataGridViewComboBoxColumn();
            i.Items.Add("Bachillerato Tecnologico");
            j.Items.Add("Fisico,Matematicas");
            j.Items.Add("Econimico,Administrativas");
            j.Items.Add("Quimico,Biologica");
            i.HeaderText = "                      Prueba         ";
            j.HeaderText = "                 Prueba2      ";
            j.Width = 20;
            Especialidad.Columns.Add(i);
            Especialidad.Columns.Add(j);
            DataBaseUtilities.CerrarConexion();
        }

        
    }
}
