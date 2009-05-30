namespace HorarioMaster.Controls
{
    partial class GridControlAComplementarias
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
            this.components = new System.ComponentModel.Container();
            this.grdAComplementarias = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmnuAComplementarias = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuItemBorrar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdAComplementarias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.cmnuAComplementarias.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAComplementarias
            // 
            this.grdAComplementarias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAComplementarias.Location = new System.Drawing.Point(0, 0);
            this.grdAComplementarias.MainView = this.gridView1;
            this.grdAComplementarias.Name = "grdAComplementarias";
            this.grdAComplementarias.Size = new System.Drawing.Size(934, 181);
            this.grdAComplementarias.TabIndex = 0;
            this.grdAComplementarias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdAComplementarias.Load += new System.EventHandler(this.grdAComplementarias_Load);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdAComplementarias;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            // 
            // cmnuAComplementarias
            // 
            this.cmnuAComplementarias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemBorrar});
            this.cmnuAComplementarias.Name = "cmnuAComplementarias";
            this.cmnuAComplementarias.Size = new System.Drawing.Size(158, 26);
            // 
            // cmnuItemBorrar
            // 
            this.cmnuItemBorrar.Name = "cmnuItemBorrar";
            this.cmnuItemBorrar.Size = new System.Drawing.Size(157, 22);
            this.cmnuItemBorrar.Text = "Borrar Renglon";
            this.cmnuItemBorrar.Click += new System.EventHandler(this.cmnuItemBorrar_Click);
            // 
            // GridControlAComplementarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdAComplementarias);
            this.Name = "GridControlAComplementarias";
            this.Size = new System.Drawing.Size(934, 181);
            ((System.ComponentModel.ISupportInitialize)(this.grdAComplementarias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cmnuAComplementarias.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAComplementarias;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmnuAComplementarias;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemBorrar;
    }
}
