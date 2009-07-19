namespace HorarioMaster.UI
{
    partial class frmSkins
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbTemas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lSkin = new DevExpress.XtraEditors.LabelControl();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTemas.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTemas
            // 
            this.cmbTemas.EditValue = "";
            this.cmbTemas.Location = new System.Drawing.Point(48, 26);
            this.cmbTemas.Name = "cmbTemas";
            this.cmbTemas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTemas.Size = new System.Drawing.Size(234, 20);
            this.cmbTemas.TabIndex = 0;
            this.cmbTemas.EditValueChanged += new System.EventHandler(this.cmbTemas_EditValueChanged);
            // 
            // lSkin
            // 
            this.lSkin.Location = new System.Drawing.Point(12, 29);
            this.lSkin.Name = "lSkin";
            this.lSkin.Size = new System.Drawing.Size(30, 13);
            this.lSkin.TabIndex = 1;
            this.lSkin.Text = "Tema:";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(72, 76);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(167, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSkins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 111);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.lSkin);
            this.Controls.Add(this.cmbTemas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSkins";
            this.Text = "Cambiar Tema";
            this.Load += new System.EventHandler(this.frmSkins_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbTemas.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmbTemas;
        private DevExpress.XtraEditors.LabelControl lSkin;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}