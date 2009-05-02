using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HorarioMaster;
using System.IO;
using System.Data.OleDb;
using HorarioMaster.Controls;


namespace HorarioMaster.Controls
{
    public partial class XtraDGVMaster : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraDGVMaster()
        {
            InitializeComponent();
        }
        
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private OleDbDataAdapter da;
        private BindingSource Binding1 = new BindingSource();
        private DataTable tabla = new DataTable();

        public void Fill_XtraDGV(string sSql)
        {
            string cnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + PathDataBase;
            da = new OleDbDataAdapter(sSql, cnn);
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);
            this.da.Fill(tabla);
            Binding1.DataSource = tabla;
            gridControl1.DataSource = Binding1;
            

        }


    
    }
}
