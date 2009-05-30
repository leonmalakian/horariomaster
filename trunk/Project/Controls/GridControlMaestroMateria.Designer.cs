namespace HorarioMaster.Controls
{
    partial class GridControlMaestroMateria
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdMaestroMateria = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaestroMateria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMaestroMateria
            // 
            this.grdMaestroMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaestroMateria.Location = new System.Drawing.Point(0, 0);
            this.grdMaestroMateria.MainView = this.gridView1;
            this.grdMaestroMateria.Name = "grdMaestroMateria";
            this.grdMaestroMateria.Size = new System.Drawing.Size(530, 167);
            this.grdMaestroMateria.TabIndex = 1;
            this.grdMaestroMateria.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdMaestroMateria.Load += new System.EventHandler(this.grdMaestroMateria_Load);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdMaestroMateria;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // GridControlMaestroMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdMaestroMateria);
            this.Name = "GridControlMaestroMateria";
            this.Size = new System.Drawing.Size(530, 167);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaestroMateria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMaestroMateria;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
