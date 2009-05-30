using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace HorarioMaster.UI
{
    public partial class frmParametersGroups : DevExpress.XtraEditors.XtraForm
    {
        public frmParametersGroups()
        {
            InitializeComponent();
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        static public string sSql = "";
        private frmReportGroups HG = new frmReportGroups();


        private void frmParametersGroups_Load(object sender, EventArgs e)
        {
            DataBaseUtilities.OpenConnection(PathDataBase);
            cmbGroups = DataBaseUtilities.FillComboBoxEdit("Select Grupo From MaestroMateria", "Grupo", cmbGroups);
            DataBaseUtilities.CloseConnection();
            DataBaseUtilities.OpenConnection(PathDataBase);
            cmbEspecial = DataBaseUtilities.FillComboBoxEdit("Select Nombre From Especialidad", "Nombre", cmbEspecial);
            DataBaseUtilities.CloseConnection(); 

        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGroups.Enabled = false;            
            cmbSemester.Enabled = false;
            cmbEspecial.Enabled = false;  
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSemester.Enabled = false;
            cmbSemester.Enabled = false;
            cmbShift.Enabled = false;
            cmbEspecial.Enabled = false; 

        }

        private void cmbsemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGroups.Enabled = false;
            cmbShift.Enabled = false;
            cmbEspecial.Enabled = false; 
        }

        private void cmbEspecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGroups.Enabled = false;
            cmbShift.Enabled = false;
            cmbSemester.Enabled = false; 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbGroups.Enabled && cmbSemester.Enabled && cmbShift.Enabled && cmbEspecial.Enabled)
            {
               sSql  = @"SELECT Grupos.Semestre, Grupos.Grupo, Grupos.SG, Grupos.Turno, Grupos.Especialidad, HorarioMaterias.Dia, HorarioMaterias.Hora, HorarioMaterias.Materia
                         FROM Grupos INNER JOIN (MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia) ON Grupos.SG = MaestroMateria.Grupo";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbGroups.Enabled)
            {
                sSql = @"SELECT Grupos.Semestre, Grupos.Grupo, Grupos.SG, Grupos.Turno, Grupos.Especialidad, HorarioMaterias.Dia, HorarioMaterias.Hora, HorarioMaterias.Materia
                         FROM Grupos INNER JOIN (MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia) ON Grupos.SG = MaestroMateria.Grupo
                         WHERE (((Grupos.SG)='" + cmbGroups.Text + "'))";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbSemester.Enabled)
            {
                sSql = @"SELECT Grupos.Semestre, Grupos.Grupo, Grupos.SG, Grupos.Turno, Grupos.Especialidad, HorarioMaterias.Dia, HorarioMaterias.Hora, HorarioMaterias.Materia
                         FROM Grupos INNER JOIN (MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia) ON Grupos.SG = MaestroMateria.Grupo
                         WHERE (((Grupos.Semestre)='" + cmbSemester.Text + "'))";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbShift.Enabled)
            {
                  sSql = @"SELECT Grupos.Semestre, Grupos.Grupo, Grupos.SG, Grupos.Turno, Grupos.Especialidad, HorarioMaterias.Dia, HorarioMaterias.Hora, HorarioMaterias.Materia
                         FROM Grupos INNER JOIN (MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia) ON Grupos.SG = MaestroMateria.Grupo
                         WHERE (((Grupos.Turno)='" + cmbShift.Text + "'))";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbEspecial.Enabled)
            {
               sSql = @"SELECT Grupos.Semestre, Grupos.Grupo, Grupos.SG, Grupos.Turno, Grupos.Especialidad, HorarioMaterias.Dia, HorarioMaterias.Hora, HorarioMaterias.Materia
                         FROM Grupos INNER JOIN (MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia) ON Grupos.SG = MaestroMateria.Grupo
                         WHERE (((Grupos.Especialidad)='" + cmbEspecial.Text + "'))";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            cmbGroups.Text = "";
            cmbSemester.Text = "";
            cmbEspecial.Text = "";
            cmbShift.Text = "";
            cmbGroups.Enabled = true;
            cmbSemester.Enabled = true;
            cmbEspecial.Enabled = true;
            cmbShift.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}