namespace HorarioMaster.Controls
{
    partial class GridControlGrupos
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
            this.grdGrupos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmnuGrupos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuItemBorrar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.cmnuGrupos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdGrupos
            // 
            this.grdGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGrupos.Location = new System.Drawing.Point(0, 0);
            this.grdGrupos.MainView = this.gridView1;
            this.grdGrupos.Name = "grdGrupos";
            this.grdGrupos.Size = new System.Drawing.Size(610, 266);
            this.grdGrupos.TabIndex = 1;
            this.grdGrupos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdGrupos.Load += new System.EventHandler(this.grdGrupos_Load);
            this.grdGrupos.Leave += new System.EventHandler(this.grdGrupos_Leave);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdGrupos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            // 
            // cmnuGrupos
            // 
            this.cmnuGrupos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemBorrar});
            this.cmnuGrupos.Name = "cmnuGrupos";
            this.cmnuGrupos.Size = new System.Drawing.Size(158, 26);
            // 
            // cmnuItemBorrar
            // 
            this.cmnuItemBorrar.Name = "cmnuItemBorrar";
            this.cmnuItemBorrar.Size = new System.Drawing.Size(157, 22);
            this.cmnuItemBorrar.Text = "Borrar Renglon";
            this.cmnuItemBorrar.Click += new System.EventHandler(this.cmnuItemBorrar_Click);
            // 
            // GridControlGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdGrupos);
            this.Name = "GridControlGrupos";
            this.Size = new System.Drawing.Size(610, 266);
            ((System.ComponentModel.ISupportInitialize)(this.grdGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cmnuGrupos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdGrupos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmnuGrupos;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemBorrar;
    }
}
