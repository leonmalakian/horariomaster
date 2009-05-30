using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HorarioMaster.Controls;
using System.IO;
using System.Data.OleDb;
using HorarioMaster;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace HorarioMaster.Controls
{
    public partial class frmGridMateria : DevExpress.XtraEditors.XtraForm
    {
        static string sName = "";
        public frmGridMateria(string sNamePersonal)
        {
            sName = sNamePersonal;
            InitializeComponent();
        }

        private void frmGridMateria_Load(object sender, EventArgs e)
        {
            GridControlAsignaMateria grdAsignaMateria = new GridControlAsignaMateria(sName);
            grdAsignaMateria.Parent = this;
            grdAsignaMateria.Dock = DockStyle.Fill;
        }
    }
}