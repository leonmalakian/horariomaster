using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HorarioMaster.Controls
{
    public partial class frmGridClave : DevExpress.XtraEditors.XtraForm
    {
        static string sName = "";
        public frmGridClave(string sNamePersonal)
        {
            sName = sNamePersonal;
            InitializeComponent();
        }

        private void frmGridClave_Load(object sender, EventArgs e)
        {
            GridControlClave grdClave = new GridControlClave(sName);
            grdClave.Parent = this;
            grdClave.Dock = DockStyle.Fill;
            
        }

    }
}