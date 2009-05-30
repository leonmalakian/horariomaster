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
    public partial class frmGridPlaza : DevExpress.XtraEditors.XtraForm
    {
        static string sName = "";
        public frmGridPlaza(string sNamePersonal)
        {
            sName = sNamePersonal;
            InitializeComponent();
        }

        private void frmGridPlaza_Load(object sender, EventArgs e)
        {
            GridControlPlaza grdPlaza = new GridControlPlaza(sName);
            grdPlaza.Parent = this;
            grdPlaza.Dock = DockStyle.Fill;
            
        }

    }
}