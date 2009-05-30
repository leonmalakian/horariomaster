using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.IO;


namespace HorarioMaster.UI
{
    public partial class frmReportGeneral : DevExpress.XtraEditors.XtraForm
    {
        public frmReportGeneral()
        {
            InitializeComponent();
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        static public string sSql = "";
      
        private void frmReportGeneral_Load(object sender, EventArgs e)
        {
            sSql = @"SELECT Grupos.Semestre, Grupos.Grupo, Grupos.SG, Grupos.Turno, Grupos.Especialidad, HorarioMaterias.Dia, HorarioMaterias.Hora, HorarioMaterias.Materia,HorarioMaterias.Maestro
                     FROM Grupos INNER JOIN (MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia) ON Grupos.SG = MaestroMateria.Grupo";
            // Creas un reporte vacio            
            Reports.ScheduleGeneral CR = new Reports.ScheduleGeneral();
            //Creas un Objeto del DataSet*/
            DataSets.DataSetReports ds = new DataSets.DataSetReports();
            //Creas un Data Adapter
            DataBaseUtilities.OpenConnection(PathDataBase);
            OleDbDataAdapter daScheduleGroups = DataBaseUtilities.FillDataAdapter(sSql);
            //Llenas el Dataset Table*/
            daScheduleGroups.Fill(ds.DTScheduleGroups);
            // Llenas el Reporte con lo que tiene el DataSet Table */
            CR.SetDataSource(ds);
            OleDbDataAdapter daCampus = DataBaseUtilities.FillDataAdapter("Select Nombre,Subdirector,Director from Plantel");
            daCampus.Fill(ds.DTCampus);
            CR.SetDataSource(ds);
            DataBaseUtilities.CloseConnection();
            //Luego viualizas tu reporte en control CrystalReportViewer */
            crystalReportViewerGeneral.ReportSource = CR;            
        }
    }
}