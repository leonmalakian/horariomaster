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
            DataBaseUtilities.OpenConnection(PathDataBase);
            cmbSemester = DataBaseUtilities.FillComboBoxEdit("SELECT Grupos.Semestre FROM Grupos INNER JOIN horariomaterias ON Grupos.SG = horariomaterias.Grupo WHERE (((Grupos.Semestre)='1'))", "Semestre", cmbSemester);
            DataBaseUtilities.CloseConnection();
            DataBaseUtilities.OpenConnection(PathDataBase);
            cmbShift = DataBaseUtilities.FillComboBoxEdit("SELECT Grupos.Turno FROM Grupos INNER JOIN horariomaterias ON Grupos.SG = horariomaterias.Grupo", "Turno", cmbShift);
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
                sSql = @"SELECT horariomaterias.Dia, Grupos.Especialidad, horariomaterias.Hora, horariomaterias.Maestro, horariomaterias.Materia, Grupos.Semestre, Grupos.SG, Grupos.Turno, Grupos.SG, Grupos.SG
                         FROM Grupos INNER JOIN horariomaterias ON Grupos.SG = horariomaterias.Grupo";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbGroups.Enabled)
            {
                sSql = @"SELECT horariomaterias.Dia, Grupos.Especialidad, horariomaterias.Hora, horariomaterias.Maestro, horariomaterias.Materia, Grupos.Semestre, Grupos.SG, Grupos.Turno, Grupos.SG, Grupos.SG
                         FROM Grupos INNER JOIN horariomaterias ON Grupos.SG = horariomaterias.Grupo
                         WHERE (((Grupos.SG)='"+cmbGroups.Text+"'))";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbSemester.Enabled)
            {
                sSql = @"SELECT horariomaterias.Dia, Grupos.Especialidad, horariomaterias.Hora, horariomaterias.Maestro, horariomaterias.Materia, Grupos.Semestre, Grupos.SG, Grupos.Turno, Grupos.SG, Grupos.SG
                         FROM Grupos INNER JOIN horariomaterias ON Grupos.SG = horariomaterias.Grupo
                         WHERE (((Grupos.Semestre)='"+cmbSemester.Text+"'))";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbShift.Enabled)
            {
                  sSql = @"SELECT horariomaterias.Dia, Grupos.Especialidad, horariomaterias.Hora, horariomaterias.Maestro, horariomaterias.Materia, Grupos.Semestre, Grupos.SG, Grupos.Turno
                           FROM Grupos INNER JOIN horariomaterias ON Grupos.SG = horariomaterias.Grupo
                           WHERE (((Grupos.Turno)='"+cmbShift.Text+"'))";
                HG.FillScheduleGroups(sSql);
                HG.ShowDialog();
            }
            else if (cmbEspecial.Enabled)
            {
               sSql = @"SELECT horariomaterias.Dia, Grupos.Especialidad, horariomaterias.Hora, horariomaterias.Maestro, horariomaterias.Materia, Grupos.Semestre, Grupos.SG, Grupos.Turno
                        FROM Grupos INNER JOIN horariomaterias ON Grupos.SG = horariomaterias.Grupo
                        WHERE (((Grupos.Especialidad)='"+cmbEspecial.Text+"'))";
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