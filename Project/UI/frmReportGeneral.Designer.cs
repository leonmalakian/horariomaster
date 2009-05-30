namespace HorarioMaster.UI
{
    partial class frmReportGeneral
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
            this.crystalReportViewerGeneral = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerGeneral
            // 
            this.crystalReportViewerGeneral.ActiveViewIndex = -1;
            this.crystalReportViewerGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerGeneral.DisplayGroupTree = false;
            this.crystalReportViewerGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerGeneral.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerGeneral.Name = "crystalReportViewerGeneral";
            this.crystalReportViewerGeneral.SelectionFormula = "";
            this.crystalReportViewerGeneral.Size = new System.Drawing.Size(292, 266);
            this.crystalReportViewerGeneral.TabIndex = 0;
            this.crystalReportViewerGeneral.ViewTimeSelectionFormula = "";
            // 
            // frmReportGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.crystalReportViewerGeneral);
            this.Name = "frmReportGeneral";
            this.Text = "Reporte General";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerGeneral;
    }
}