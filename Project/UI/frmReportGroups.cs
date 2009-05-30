using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.OleDb;

namespace HorarioMaster.UI
{
    public partial class frmReportGroups : DevExpress.XtraEditors.XtraForm
    {
        public frmReportGroups()
        {
            InitializeComponent();
        }

        private void frmReportGroups_Load(object sender, EventArgs e)
        {

        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        static public string sSql = "";
       
        public void FillScheduleGroups(string sSql)
        {
            // Creas un reporte vacio            
            Reports.ScheduleGroups CR = new Reports.ScheduleGroups();
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
            crystalReportViewerGroups.ReportSource = CR;
        }
    }
}