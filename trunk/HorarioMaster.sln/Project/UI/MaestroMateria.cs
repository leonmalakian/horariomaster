using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HorarioMaster
{
    public partial class MaestroMateria : Form
    {
        public MaestroMateria()
        {
            InitializeComponent();
        }

        static public string PathDataBase = Path.GetDirectoryName(Application.ExecutablePath) + @"\Global.mdb";
       
        private void MaestroMateria_Load(object sender, EventArgs e)
        {
            HorarioMaster.DataBaseUtilities.OpenConnection(PathDataBase);
            string[] Headers = new string[]{"Index","Maestro","Materia","Clave","Grupo"};
            string sSql = "Select * From MaestroMateria";
            dataGridView1= HorarioMaster.DataBaseUtilities.FillDataGridView(sSql,dataGridView1,"HorarioMateria",Headers);
            comboBox1 = HorarioMaster.DataBaseUtilities.FillComboBox("Select Nombre From Personal WHERE Puesto='DOCENTE'", "Nombre", comboBox1);
            comboBox2 = HorarioMaster.DataBaseUtilities.FillComboBox("Select Nombre From Materias", "Nombre", comboBox2);
            comboBox3 = HorarioMaster.DataBaseUtilities.FillComboBox("Select SG From Grupos", "SG", comboBox3);
            HorarioMaster.DataBaseUtilities.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HorarioMaster.DataBaseUtilities.OpenConnection(PathDataBase);
            string sSql = "INSERT INTO MaestroMateria (Maestro,Materia,Clave,Grupo) Values('" + comboBox1.Text + "','" + comboBox2.Text +
                           "','" + textBox1.Text + "','" + comboBox3.Text + "')";
            HorarioMaster.DataBaseUtilities.ExecuteNonSql(sSql);
            HorarioMaster.DataBaseUtilities.CloseConnection();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            HorarioMaster.DataBaseUtilities.OpenConnection(PathDataBase);
            string sql = "Select Clave From Materias Where Nombre='" + comboBox2.Text + "'";
            System.Data.OleDb.OleDbDataReader dr = HorarioMaster.DataBaseUtilities.ExecuteSql(sql);            
            dr.Read();
            textBox1.Text = dr["Clave"].ToString();
            HorarioMaster.DataBaseUtilities.CloseConnection();            
        }
    }
}
