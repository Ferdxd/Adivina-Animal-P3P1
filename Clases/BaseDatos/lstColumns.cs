using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Juego_Adivina_Animal_P1P3.Clases.BaseDatos
{
    class lstColumns
    {
        public List<string> animal = new List<string>();
        public List<string> pregunta = new List<string>();
        public List<string> respuesta = new List<string>();

        public List<string> listar(string colum)
        {
            clsConexionBd cn = new clsConexionBd();
            List<string> list = new List<string>();

            DataTable dt = cn.consultaTablaDirecta("SELECT *  FROM animals");

            foreach (DataRow dr in dt.Rows)
            {
               
                list.Add(dr[colum].ToString());

            }
           
            return list;
        }

        public void cargarDatosList()
        {
            vaciarlista(animal);
            vaciarlista(pregunta);
            vaciarlista(respuesta);
          
            animal = listar("animal");
            pregunta = listar("pregunta");
            respuesta = listar("respuesta");  
        }

        public List<string> vaciarlista(List<string> lista)
        {
            lista.Clear();          
            return lista;
        }

     

    }
}
