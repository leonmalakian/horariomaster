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

namespace HorarioMaster.Controls
{
    public partial class frmDGVMaster : DevExpress.XtraEditors.XtraForm
    {
        public frmDGVMaster()
        {
            InitializeComponent();
        }
        string sSql="";
        string sField = "";
        private GridMasterControl Grid1 = new GridMasterControl();

        private void frmDGVMaster_Load(object sender, EventArgs e)
        {
            Grid1.FillGridMaster(sSql, sField, true);
            Grid1.Dock = DockStyle.Fill;
            Grid1.Parent = this;
        }
        public void CaptureParams(string sql, string field)
        {
            sSql = sql;
            sField = field;
        }
    }
}