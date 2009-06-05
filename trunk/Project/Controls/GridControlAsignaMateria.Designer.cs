namespace HorarioMaster.Controls
{
    partial class GridControlAsignaMateria
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
            this.grdAsignaMateria = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmnuAsignaMateria = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuBorrarItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsignaMateria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.cmnuAsignaMateria.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAsignaMateria
            // 
            this.grdAsignaMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAsignaMateria.Location = new System.Drawing.Point(0, 0);
            this.grdAsignaMateria.MainView = this.gridView1;
            this.grdAsignaMateria.Name = "grdAsignaMateria";
            this.grdAsignaMateria.Size = new System.Drawing.Size(501, 235);
            this.grdAsignaMateria.TabIndex = 1;
            this.grdAsignaMateria.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdAsignaMateria.Load += new System.EventHandler(this.grdAsignaMateria_Load);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdAsignaMateria;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            // 
            // cmnuAsignaMateria
            // 
            this.cmnuAsignaMateria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuBorrarItem});
            this.cmnuAsignaMateria.Name = "contextMenuStrip1";
            this.cmnuAsignaMateria.Size = new System.Drawing.Size(159, 26);
            this.cmnuAsignaMateria.Text = "Borrar Registro";
            // 
            // cmnuBorrarItem
            // 
            this.cmnuBorrarItem.Name = "cmnuBorrarItem";
            this.cmnuBorrarItem.Size = new System.Drawing.Size(158, 22);
            this.cmnuBorrarItem.Text = "Borrar Registro";
            this.cmnuBorrarItem.Click += new System.EventHandler(this.cmnuBorrarItem_Click);
            // 
            // GridControlAsignaMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdAsignaMateria);
            this.Name = "GridControlAsignaMateria";
            this.Size = new System.Drawing.Size(501, 235);
            ((System.ComponentModel.ISupportInitialize)(this.grdAsignaMateria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cmnuAsignaMateria.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAsignaMateria;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmnuAsignaMateria;
        private System.Windows.Forms.ToolStripMenuItem cmnuBorrarItem;
    }
}
