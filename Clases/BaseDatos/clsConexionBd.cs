using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Juego_Adivina_Animal_P1P3.Clases.BaseDatos
{
    class clsConexionBd
    {
       
        public static MySqlConnection Conexion()
        {
            string servidor="localhost";
            string bd="arboldecisionesbd";
            string usuario="root";
            string password="";

            string _conexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password;
           

            try
            {
                MySqlConnection ConexionBD = new MySqlConnection(_conexion);
             //   Console.WriteLine("Conexion Exitosa!!! ");
                return ConexionBD;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error Al Establecer Conexion Con La Base De Datos: " + ex.Message);
                return null;
            }
        }

        public Boolean validacion(string dato,Boolean bandera)
        {
        
            lstColumns colums = new lstColumns();
            colums.cargarDatosList();
            for (int i = 0; i < colums.animal.Count; i++)
            {
                if (dato == colums.animal[i])
                {
                    bandera = false;
                }
            }
            return bandera;
        }


        public void insertar(string dato,string pregunta,string answer)
        {
            Boolean bandera = true;
            bandera=validacion(dato,bandera);
            
            if (bandera) {

                string query = "insert into animals (animal,pregunta,respuesta) values ('" + dato + "','" + pregunta + "','" + answer + "')";
                MySqlConnection conexionBd = Conexion();
                conexionBd.Open();
                try
                {
                    MySqlCommand comando = new MySqlCommand(query, conexionBd);
                    comando.ExecuteNonQuery();
                   
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error" + ex.Message);

                }
                finally
                {
                    conexionBd.Close();
                } 
            }
        }


        public DataTable consultaTablaDirecta(String sqll)
        {
            MySqlConnection conexionBd = Conexion();
            conexionBd.Open();
            MySqlDataReader dr;
            MySqlCommand comm = new MySqlCommand(sqll, conexionBd);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            conexionBd.Close();
            return dataTable;
        }



    }
}
