namespace HorarioMaster.Controls
{
    partial class GridControlEspecialidad
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
            this.grdEspecialidad = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmnuEspecialidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuItemBorrar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdEspecialidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.cmnuEspecialidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEspecialidad
            // 
            this.grdEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEspecialidad.Location = new System.Drawing.Point(0, 0);
            this.grdEspecialidad.MainView = this.gridView1;
            this.grdEspecialidad.Name = "grdEspecialidad";
            this.grdEspecialidad.Size = new System.Drawing.Size(827, 150);
            this.grdEspecialidad.TabIndex = 0;
            this.grdEspecialidad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdEspecialidad.Load += new System.EventHandler(this.grdEspecialidad_Load);
            this.grdEspecialidad.Leave += new System.EventHandler(this.grdEspecialidad_Leave);
            
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdEspecialidad;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            
            
            
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            // 
            // cmnuEspecialidad
            // 
            this.cmnuEspecialidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemBorrar});
            this.cmnuEspecialidad.Name = "cmnuEspecialidad";
            this.cmnuEspecialidad.Size = new System.Drawing.Size(158, 26);
            // 
            // cmnuItemBorrar
            // 
            this.cmnuItemBorrar.Name = "cmnuItemBorrar";
            this.cmnuItemBorrar.Size = new System.Drawing.Size(157, 22);
            this.cmnuItemBorrar.Text = "Borrar Renglon";
            this.cmnuItemBorrar.Click += new System.EventHandler(this.cmnuItemBorrar_Click);
            // 
            // GridControlEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdEspecialidad);
            this.Name = "GridControlEspecialidad";
            this.Size = new System.Drawing.Size(827, 150);
            ((System.ComponentModel.ISupportInitialize)(this.grdEspecialidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cmnuEspecialidad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdEspecialidad;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmnuEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemBorrar;
    }
}
