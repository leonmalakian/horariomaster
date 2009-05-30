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

namespace HorarioMaster.UI
{
    public partial class AComplementarias : DevExpress.XtraEditors.XtraForm
    {
        public AComplementarias()
        {
            InitializeComponent();
        }
        #region Global's
        GridControlAComplementarias AC = new GridControlAComplementarias();
        #endregion

        private void AComplementarias_Load(object sender, EventArgs e)
        {
            
            AC.Parent = groupControl1;
            AC.Dock = DockStyle.Fill;

        }


    }
}