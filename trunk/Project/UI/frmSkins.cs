using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HorarioMaster.UI
{
    public partial class frmSkins : DevExpress.XtraEditors.XtraForm
    {
        public frmSkins()
        {
            InitializeComponent();
        }
        public delegate void CambiarSkin(string sTema);
        public static event CambiarSkin EnviarTema;

        private void cmbTemas_EditValueChanged(object sender, EventArgs e)
        {
            EnviarTema(cmbTemas.Text);
        }

        private void frmSkins_Load(object sender, EventArgs e)
        {
            cmbTemas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                cmbTemas.Properties.Items.Add(skin.SkinName);
            }
            cmbTemas.Text = Properties.Settings.Default.LookandFeel;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LookandFeel = cmbTemas.Text;         
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnviarTema(Properties.Settings.Default.LookandFeel);
            this.Close();
        }
    }
}