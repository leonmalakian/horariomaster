using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;


namespace HorarioMaster
{
    class Utilities
    {
        public Utilities() { }

        public struct Materias_Data
        {
            public string clave;
            public string Grupo;
            public string Horas;
            public string Nombre;
            public Materias_Data(string Data1, string Data2, string Data3, string Data4)
            {
                clave = Data1;
                Grupo = Data2;
                Horas = Data3;
                Nombre = Data4;
            }
        }
        
        public static ListBox LLenarListbox(List<string> Datos,int Espacios,ListBox LB)
        {
            int indiceB = 0;           
            for (int indice = 0; indice < Datos.Count; indice++)
            {
                for (indiceB = 1; indiceB <= Espacios; indiceB++)
                {
                    Datos.Insert(indice + indiceB, ""); 
                }
                indice = indice + indiceB-1;
            }
            LB.Items.AddRange(Datos.ToArray());            
            return LB;
        }

        public static string[,] Horario = new string[,]{ {"07:00-08:00", "14:00-15:00"},{"08:00-09:00","15:00-16:00"},
                                                          {"09:00-10:00", "16:00-17:00"},{"10:00-11:00","17:00-18:00"},
                                                          {"11:00-12:00","18:00-19:00"},{"12:00-13:00","19:00-20:00"},
                                                          {"13:00-14:00","20:00-21:00"}};
               
        public static bool Find(int Item,string Maestro)
        {
            string SQL = "";
            //bool result = false;
            string[] Dia = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };
            if (Item <= 4)
            {
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='"+Maestro+"') AND ((HorarioMaterias.Hora)='"+Horario[0,0]+@"') 
                        AND ((HorarioMaterias.Dia)='"+Dia[Item]+"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[0, 1] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + "'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;               
            }
            else if (Item > 4 && Item <= 9)
            {
                Item = Item - 5;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[1, 0] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[1, 1] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;    
            }
            else if (Item > 9 && Item <= 14)
            {
                Item = Item - 10;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[2, 0] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[2, 1] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;    
            }
            else if (Item > 14 && Item <= 19)
            {
                Item = Item - 15;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[3, 0] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[3, 1] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;    
            }
            else if (Item > 19 && Item <= 24)
            {
                Item = Item - 20;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[4, 0] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[4, 1] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;    
            }
            else if (Item > 24 && Item <= 29)
            {
                Item = Item - 25;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[5, 0] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[5, 1] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;    
            }
            else
            {
                Item = Item - 30;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[6, 0] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;
                SQL = @"SELECT HorarioMaterias.Hora, HorarioMaterias.Dia
                        FROM MaestroMateria INNER JOIN HorarioMaterias ON MaestroMateria.Materia = HorarioMaterias.Materia
                        WHERE (((MaestroMateria.Maestro)='" + Maestro + "') AND ((HorarioMaterias.Hora)='" + Horario[6, 1] + @"') 
                        AND ((HorarioMaterias.Dia)='" + Dia[Item] + @"'))";
                if (HorarioMaster.DataBaseUtilities.RecordExist(SQL)) return true;    
            }
            return false;                                
        }

        //public static Label[] GenerarHorario(List<int> UsedColor, Label[] labels,HorarioMaster.frmHorarioGrupo.Materias_Data[] Materias, Color[] color,ComboBox Grupos)
        //{
        //    string Maestro = null;
        //    UsedColor.Clear();
        //    foreach (Label label in labels)
        //    { label.Text = ""; label.BackColor = Color.White; }
        //    Array.Clear(Materias, 0, 15);
        //    OleDbDataReader dr= HorarioMaster.DataBaseUtilities.EjecutaSql("SELECT * FROM materias");
        //    int Index = 0;
        //    while (dr.Read())
        //    {
        //        if (dr["SG"].ToString() == Grupos.Text)
        //        {
        //            Materias[Index].Nombre = dr["Nombre"].ToString();
        //            Materias[Index].Horas = dr["HC"].ToString();
        //            Index++;
        //        }
        //    }
        //    for (int LeerStruct = 0; LeerStruct <= Index; LeerStruct++)
        //    {
        //        string SQL = "Select Maestro From MaestroMateria Where Materia='" + Materias[LeerStruct].Nombre + "'";
        //        dr = HorarioMaster.DataBaseUtilities.EjecutaSql(SQL);
        //        if (Materias[LeerStruct].Nombre != null)
        //        {
        //            if (dr.HasRows)
        //            { dr.Read(); Maestro = dr["Maestro"].ToString(); }
        //            else
        //            {
        //                MessageBox.Show("Hace Falta asignar Maestro a la materia: " + Materias[LeerStruct].Nombre + "");
        //                foreach (Label label in labels)
        //                { label.Text = ""; label.BackColor = Color.White; }
        //                return labels;
        //            }
        //        }
        //        Random r = new Random();
        //        Random ColorRandom = new Random();
        //        bool empty = true;
        //        bool empty2 = true;
        //        int ColorNumber = ColorRandom.Next(115);
        //        while (empty2)
        //        {
        //            System.Threading.Thread.Sleep(100);
        //            if (UsedColor.BinarySearch(ColorNumber) < 0)
        //            {
        //                UsedColor.Add(ColorNumber);
        //                empty2 = false;
        //            }
        //        }
        //        for (int Horas = 0; Horas < Convert.ToInt32(Materias[LeerStruct].Horas); Horas++)
        //        {
        //            while (empty)
        //            {
        //                int n = r.Next(34);
        //                if (!Find(n, Maestro))
        //                {
        //                    if (labels[n].Text == "")
        //                    {
        //                        labels[n].Text = Materias[LeerStruct].Nombre;
        //                        labels[n].BackColor = color[ColorNumber];
        //                        empty = false;
        //                    }
        //                }
        //            }
        //            empty = true;
        //        }
        //        empty2 = true;
        //    }
        //    return labels;
        //}

        public static void LLenarHorario(Label[] labels, string SQL, Color[] color)
        {
            List<int> UsedColor = new List<int>();
            List<string> UsedMateria = new List<string>();
            Random ColorRandom = new Random();
            int ColorNumber = 0;
            int Elemento = 0;          
            OleDbDataReader dr = HorarioMaster.DataBaseUtilities.ExecuteSql(SQL);
            while (dr.Read())
            {
                Elemento=BuscaIndex(UsedMateria, dr["Materia"].ToString());
                if (Elemento == -1)
                {
                    bool empty = true;
                    ColorNumber = ColorRandom.Next(115);
                    while (empty)
                    {
                        System.Threading.Thread.Sleep(100);
                        if (UsedColor.BinarySearch(ColorNumber) < 0)
                        {
                            UsedColor.Add(ColorNumber);
                            UsedMateria.Add(dr["Materia"].ToString());
                            Elemento = UsedMateria.Count - 1;
                            empty = false;
                        }
                    }
                }
                labels[Convert.ToInt32(dr["Posicion"])].Text = dr["Materia"].ToString();
                labels[Convert.ToInt32(dr["Posicion"])].BackColor = color[UsedColor[Elemento]];                
            }
        }        

        public static int BuscaIndex(List<string> Nombres,string Elemento)
        {
            int contador = 0;
            foreach (string Nombre in Nombres.ToArray())
            {
                if (Elemento == Nombre) return contador;
                contador++;
            }
            return -1;
        }
    }
}
