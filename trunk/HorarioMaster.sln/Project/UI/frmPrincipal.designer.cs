namespace HorarioMaster
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Altas y Modificaciones");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Crear Horarios");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Reportes");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Principal", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.altasYModificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearHorariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horarioGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horarioDeGruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horarioDeMaestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosPlantelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actividadesComplementariasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altasYModificacionesToolStripMenuItem,
            this.crearHorariosToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // altasYModificacionesToolStripMenuItem
            // 
            this.altasYModificacionesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.altasYModificacionesToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.altasYModificacionesToolStripMenuItem.Name = "altasYModificacionesToolStripMenuItem";
            this.altasYModificacionesToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.altasYModificacionesToolStripMenuItem.Text = "Altas y Modificaciones";
            this.altasYModificacionesToolStripMenuItem.Click += new System.EventHandler(this.altasYModificacionesToolStripMenuItem_Click);
            // 
            // crearHorariosToolStripMenuItem
            // 
            this.crearHorariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gruposToolStripMenuItem,
            this.maestrosToolStripMenuItem});
            this.crearHorariosToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.crearHorariosToolStripMenuItem.Name = "crearHorariosToolStripMenuItem";
            this.crearHorariosToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.crearHorariosToolStripMenuItem.Text = "Crear Horarios";
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.gruposToolStripMenuItem.Text = "Grupos";
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.maestrosToolStripMenuItem.Text = "Maestros";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horarioGeneralToolStripMenuItem,
            this.horarioDeGruposToolStripMenuItem,
            this.horarioDeMaestrosToolStripMenuItem});
            this.reportesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // horarioGeneralToolStripMenuItem
            // 
            this.horarioGeneralToolStripMenuItem.Name = "horarioGeneralToolStripMenuItem";
            this.horarioGeneralToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.horarioGeneralToolStripMenuItem.Text = "Horario General";
            // 
            // horarioDeGruposToolStripMenuItem
            // 
            this.horarioDeGruposToolStripMenuItem.Name = "horarioDeGruposToolStripMenuItem";
            this.horarioDeGruposToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.horarioDeGruposToolStripMenuItem.Text = "Horario de Grupos";
            // 
            // horarioDeMaestrosToolStripMenuItem
            // 
            this.horarioDeMaestrosToolStripMenuItem.Name = "horarioDeMaestrosToolStripMenuItem";
            this.horarioDeMaestrosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.horarioDeMaestrosToolStripMenuItem.Text = "Horario de Maestros";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosPlantelToolStripMenuItem,
            this.actividadesComplementariasToolStripMenuItem});
            this.configuracionToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // datosPlantelToolStripMenuItem
            // 
            this.datosPlantelToolStripMenuItem.Name = "datosPlantelToolStripMenuItem";
            this.datosPlantelToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.datosPlantelToolStripMenuItem.Text = "Datos Plantel";
            this.datosPlantelToolStripMenuItem.Click += new System.EventHandler(this.datosPlantelToolStripMenuItem_Click);
            // 
            // actividadesComplementariasToolStripMenuItem
            // 
            this.actividadesComplementariasToolStripMenuItem.Name = "actividadesComplementariasToolStripMenuItem";
            this.actividadesComplementariasToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.actividadesComplementariasToolStripMenuItem.Text = "Actividades Complementarias";
            this.actividadesComplementariasToolStripMenuItem.Click += new System.EventHandler(this.actividadesComplementariasToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Size = new System.Drawing.Size(784, 382);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "tNodeAltasModificaciones";
            treeNode5.Text = "Altas y Modificaciones";
            treeNode6.Name = "tNodeCrearHorario";
            treeNode6.Text = "Crear Horarios";
            treeNode7.Name = "tNodeReportes";
            treeNode7.Text = "Reportes";
            treeNode8.Name = "tNodePrincipal";
            treeNode8.Text = "Principal";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(123, 382);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 453);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem altasYModificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearHorariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosPlantelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actividadesComplementariasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horarioGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horarioDeGruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horarioDeMaestrosToolStripMenuItem;
    }
}