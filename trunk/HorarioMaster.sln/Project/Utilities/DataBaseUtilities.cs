using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Diagnostics ;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data;
using System.IO;


namespace HorarioMaster
{
    class DataBaseUtilities
    {
        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
        private static OleDbConnection cnn = new OleDbConnection();
        
        public DataBaseUtilities() { }

        public static void OpenConnection(string DataBasePath)
        {
            if (cnn.State.ToString() == "Open")
            {
                cnn.Close();
            }
            try
            {
                cnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + DataBasePath;
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la conexion por: ", ex.InnerException.Message);
            }
        }

        public static void CloseConnection()
        {
            cnn.Close();
        }

        public static OleDbDataReader ExecuteSql(string SqlString)
        {            
            OleDbCommand SentenciaSql = new OleDbCommand(SqlString, cnn);
            OleDbDataReader dr = SentenciaSql.ExecuteReader();            
            return dr;     
        }

        public static void ExecuteNonSql(string SqlString)
        {            
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = SqlString;
            cmd.Connection = cnn;
            cmd.ExecuteNonQuery();            
        }

        //public static void UpdateDB(string SqlString)
        //{
            
        //    OleDbCommand SentenciaSql = new OleDbCommand(SqlString, cnn);
        //    OleDbDataReader dr = SentenciaSql.ExecuteReader();
            
        //}

        public static ComboBox FillComboBox(string SqlString,string Campo,ComboBox CB)
        {
             
            OleDbCommand SentenciaSql = new OleDbCommand(SqlString, cnn);
            OleDbDataReader dr = SentenciaSql.ExecuteReader();
            while (dr.Read())
            {
                if(CB.FindString(dr[Campo].ToString()) == -1 )
                {
                    CB.Items.Add(dr[Campo]);
                }                
            }
            dr.Close();            
            return CB;
        }

        public static DataGridView FillDataGridView(string SqlString, DataGridView DGV,string Table,string[] Headers)
        {
             
            OleDbDataAdapter da = new OleDbDataAdapter(SqlString, cnn);                       
            DataSet ds = new DataSet();
            da.Fill(ds, Table);
            DGV.DataSource = ds.Tables[0];
            DGV.AutoSize = DGV.AutoSize;
            int Index = 0;
            foreach (string Header in Headers)
            {
                DGV.Columns[Index].HeaderText = Header;
                DGV.Columns[Index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                
                Index++;
            }
            DGV.AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode.AllCells;
            
            return DGV;
        }
        
        public static DataGridView FillDataGridViewX(string SqlString, DataGridView DGV, string Table)
        {

            OleDbDataAdapter da = new OleDbDataAdapter(SqlString, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, Table);
            DGV.DataSource = ds.Tables[0];
            DGV.AutoSize = DGV.AutoSize;
            return DGV;
        }
        
        public OleDbConnection ConnectionState
        {
            get
            {
                return cnn;
            }
        }

        public static bool RecordExist(string SqlString)
        {             
            OleDbCommand SentenciaSql = new OleDbCommand(SqlString, cnn);
            OleDbDataReader dr = SentenciaSql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();                
                return true;
            }
            dr.Close();            
            return false;                       
        }

        public static object ReturnRecord(string SqlString,string Field)
        {
            object sTemp = null;
            OleDbCommand SentenciaSql = new OleDbCommand(SqlString, cnn);
            OleDbDataReader dr = SentenciaSql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                sTemp = dr[Field];
                dr.Close();
                return sTemp;
            }
            dr.Close();
            return "";   
        }
    }
}
