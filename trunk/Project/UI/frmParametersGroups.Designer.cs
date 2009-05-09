namespace HorarioMaster.UI
{
    partial class frmParametersGroups
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
            this.cmbGroups = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbEspecial = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbShift = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbSemester = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lGroups = new DevExpress.XtraEditors.LabelControl();
            this.lEspecial = new DevExpress.XtraEditors.LabelControl();
            this.lShift = new DevExpress.XtraEditors.LabelControl();
            this.lSemester = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroups.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEspecial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSemester.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGroups
            // 
            this.cmbGroups.Location = new System.Drawing.Point(121, 41);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGroups.Size = new System.Drawing.Size(100, 20);
            this.cmbGroups.TabIndex = 0;
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // cmbEspecial
            // 
            this.cmbEspecial.Location = new System.Drawing.Point(121, 81);
            this.cmbEspecial.Name = "cmbEspecial";
            this.cmbEspecial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEspecial.Size = new System.Drawing.Size(100, 20);
            this.cmbEspecial.TabIndex = 1;
            this.cmbEspecial.SelectedIndexChanged += new System.EventHandler(this.cmbEspecial_SelectedIndexChanged);
            // 
            // cmbShift
            // 
            this.cmbShift.Location = new System.Drawing.Point(121, 119);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbShift.Size = new System.Drawing.Size(100, 20);
            this.cmbShift.TabIndex = 2;
            this.cmbShift.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit3_SelectedIndexChanged);
            // 
            // cmbSemester
            // 
            this.cmbSemester.Location = new System.Drawing.Point(121, 164);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSemester.Size = new System.Drawing.Size(100, 20);
            this.cmbSemester.TabIndex = 3;
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbsemester_SelectedIndexChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(12, 256);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(95, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restaurar Valores";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(132, 256);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lGroups
            // 
            this.lGroups.Location = new System.Drawing.Point(31, 44);
            this.lGroups.Name = "lGroups";
            this.lGroups.Size = new System.Drawing.Size(29, 13);
            this.lGroups.TabIndex = 7;
            this.lGroups.Text = "Grupo";
            // 
            // lEspecial
            // 
            this.lEspecial.Location = new System.Drawing.Point(31, 84);
            this.lEspecial.Name = "lEspecial";
            this.lEspecial.Size = new System.Drawing.Size(58, 13);
            this.lEspecial.TabIndex = 8;
            this.lEspecial.Text = "Especialidad";
            // 
            // lShift
            // 
            this.lShift.Location = new System.Drawing.Point(31, 122);
            this.lShift.Name = "lShift";
            this.lShift.Size = new System.Drawing.Size(28, 13);
            this.lShift.TabIndex = 9;
            this.lShift.Text = "Turno";
            // 
            // lSemester
            // 
            this.lSemester.Location = new System.Drawing.Point(31, 171);
            this.lSemester.Name = "lSemester";
            this.lSemester.Size = new System.Drawing.Size(45, 13);
            this.lSemester.TabIndex = 10;
            this.lSemester.Text = "Semestre";
            // 
            // frmParametersGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 332);
            this.Controls.Add(this.lSemester);
            this.Controls.Add(this.lShift);
            this.Controls.Add(this.lEspecial);
            this.Controls.Add(this.lGroups);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.cmbEspecial);
            this.Controls.Add(this.cmbGroups);
            this.Name = "frmParametersGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros Reporte de  Grupos";
            this.Load += new System.EventHandler(this.frmParametersGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroups.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEspecial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSemester.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmbGroups;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEspecial;
        private DevExpress.XtraEditors.ComboBoxEdit cmbShift;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSemester;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lGroups;
        private DevExpress.XtraEditors.LabelControl lEspecial;
        private DevExpress.XtraEditors.LabelControl lShift;
        private DevExpress.XtraEditors.LabelControl lSemester;

    }
}