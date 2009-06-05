namespace HorarioMaster.Controls
{
    partial class GridControlPlaza
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
            this.grdPlaza = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmnuPlazas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuItemBorrar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlaza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.cmnuPlazas.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPlaza
            // 
            this.grdPlaza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlaza.Location = new System.Drawing.Point(0, 0);
            this.grdPlaza.MainView = this.gridView1;
            this.grdPlaza.Name = "grdPlaza";
            this.grdPlaza.Size = new System.Drawing.Size(874, 189);
            this.grdPlaza.TabIndex = 0;
            this.grdPlaza.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdPlaza.Load += new System.EventHandler(this.grdPlaza_Load);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdPlaza;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            // 
            // cmnuPlazas
            // 
            this.cmnuPlazas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemBorrar});
            this.cmnuPlazas.Name = "cmnuPlazas";
            this.cmnuPlazas.Size = new System.Drawing.Size(158, 26);
            // 
            // cmnuItemBorrar
            // 
            this.cmnuItemBorrar.Name = "cmnuItemBorrar";
            this.cmnuItemBorrar.Size = new System.Drawing.Size(157, 22);
            this.cmnuItemBorrar.Text = "Borrar Renglon";
            this.cmnuItemBorrar.Click += new System.EventHandler(this.cmnuItemBorrar_Click);
            // 
            // GridControlPlaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdPlaza);
            this.Name = "GridControlPlaza";
            this.Size = new System.Drawing.Size(874, 189);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlaza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cmnuPlazas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPlaza;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmnuPlazas;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemBorrar;
    }
}
