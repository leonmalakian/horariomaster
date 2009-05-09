namespace HorarioMaster.UI
{
    partial class frmReportGroups
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
            this.crystalReportViewerGroups = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerGroups
            // 
            this.crystalReportViewerGroups.ActiveViewIndex = -1;
            this.crystalReportViewerGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerGroups.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerGroups.Name = "crystalReportViewerGroups";
            this.crystalReportViewerGroups.SelectionFormula = "";
            this.crystalReportViewerGroups.Size = new System.Drawing.Size(562, 369);
            this.crystalReportViewerGroups.TabIndex = 0;
            this.crystalReportViewerGroups.ViewTimeSelectionFormula = "";
            // 
            // frmReportGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 369);
            this.Controls.Add(this.crystalReportViewerGroups);
            this.Name = "frmReportGroups";
            this.Text = "frmReportGroups";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportGroups_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerGroups;
    }
}