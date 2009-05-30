namespace HorarioMaster.Controls
{
    partial class GridControlMateria
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
            this.grdMateria = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmnuMaterias = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuItemBorrar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMateria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.cmnuMaterias.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMateria
            // 
            this.grdMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMateria.Location = new System.Drawing.Point(0, 0);
            this.grdMateria.MainView = this.gridView1;
            this.grdMateria.Name = "grdMateria";
            this.grdMateria.Size = new System.Drawing.Size(867, 195);
            this.grdMateria.TabIndex = 0;
            this.grdMateria.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdMateria.Load += new System.EventHandler(this.grdMateria_Load);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdMateria;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            // 
            // cmnuMaterias
            // 
            this.cmnuMaterias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemBorrar});
            this.cmnuMaterias.Name = "contextMenuStrip1";
            this.cmnuMaterias.Size = new System.Drawing.Size(158, 26);
            // 
            // cmnuItemBorrar
            // 
            this.cmnuItemBorrar.Name = "cmnuItemBorrar";
            this.cmnuItemBorrar.Size = new System.Drawing.Size(157, 22);
            this.cmnuItemBorrar.Text = "Borrar Renglon";
            this.cmnuItemBorrar.Click += new System.EventHandler(this.cmnuItemBorrar_Click);
            // 
            // GridControlMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdMateria);
            this.Name = "GridControlMateria";
            this.Size = new System.Drawing.Size(867, 195);
            ((System.ComponentModel.ISupportInitialize)(this.grdMateria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cmnuMaterias.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMateria;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmnuMaterias;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemBorrar;
    }
}
