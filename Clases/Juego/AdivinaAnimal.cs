using Juego_Adivina_Animal_P1P3.Clases.ArbolBinario;
using Juego_Adivina_Animal_P1P3.Clases.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Juego_Adivina_Animal_P1P3.Clases.Juego
{
    class AdivinaAnimal
    {
        private static Nodo raiz;

        
       
        string resp;
        public AdivinaAnimal()
        {
            raiz = new Nodo("Elefante");
        }

        public void loadArbol()
        {
         
            lstColumns columns = new lstColumns();//cargo la clase lstcolumns a columns
            columns.cargarDatosList();//cargo las listas a columns
            for (int i = 0; i < columns.animal.Count; i++)
            {
                                string nuevoA = columns.animal[i];

                                string pregunta = columns.pregunta[i];
                                if (columns.respuesta[i] == "si")
                                {
                                    Nodo nodo1 = new Nodo(pregunta);
                                    nodo1.izquierda = new Nodo(nuevoA);
                                    nodo1.derecha = raiz;
                                    raiz = nodo1;
                                }
                                else
                                {
                                    Nodo nodo1 = new Nodo(nuevoA);
                                    nodo1.izquierda = new Nodo(pregunta);
                                    nodo1.derecha = raiz;
                                    raiz = nodo1;

                                }                   
            }

        }



        public void graphicArbol() 
        {
            lstColumns colum = new lstColumns();
            colum.cargarDatosList();
            string tipraiz = "     ";
            string space = "";
      
            for(int i=colum.animal.Count-1; i>=0;i--)
            {
                Console.WriteLine(space+tipraiz+"_izquierda-Raiz_");
                Console.ReadKey();
                Console.WriteLine(space+ "       " + colum.animal[i]+"|"+colum.pregunta[i]+"");
                tipraiz = "sig->";
                space += "        ";
                
            }
        }

        

        public Boolean jugar(Boolean cargar)
        {
         
            if (cargar)
            {
                loadArbol();
                cargar = false;
            }
            Nodo _nodo = raiz;
        

           
            while (_nodo != null)//iteracion del arbol
            {
                    if (_nodo.izquierda != null)
                    {
                        Console.WriteLine(_nodo.valorNodo());
                        _nodo = (respuesta()) ? _nodo.izquierda : _nodo.derecha;
                    }
                    else
                    {
                   
                        Console.WriteLine($"Ya se, es un {_nodo.valorNodo()}"+"?");
              
                    

                       

                        if (respuesta())
                        {
                            Console.WriteLine("Gane!!! :)");
                        }
                        else
                        {
                       
                            animalNuevo(_nodo);
                           
                        
                        }
                        _nodo = null;
                       
                    }

        


            }
            return cargar;

        }

       
      
        public bool respuesta()
        {
            while (true)
            {
                resp = Console.ReadLine().ToLower().Trim();
                if (resp.Equals("si")) return true;
                if (resp.Equals("no")) return false;
                Console.WriteLine("La respuesta debe ser si o no");
            }
        }

    


        private void animalNuevo(Nodo _nodo)
        {

            clsConexionBd conexionbd = new clsConexionBd();

            string animalNodo = (string)_nodo.valorNodo();
            Console.WriteLine("Cual Es Tu Animal Entonces?");
            string nuevoA = Console.ReadLine();
            Console.WriteLine($"Que pregunta con respuest si/no puedo hacer que es un {nuevoA}");
            string pregunta = Console.ReadLine();
          
            Console.WriteLine($"Para un(a) {nuevoA} la respuesta es si/no?");
          

            if (conexionbd.validacion(nuevoA,true)) {
                Nodo nodo1 = new Nodo(animalNodo);
                Nodo nodo2 = new Nodo(nuevoA);
                _nodo.nuevoValor(pregunta + "?");
                if (respuesta())
                {
                    _nodo.izquierda = nodo1;
                    _nodo.derecha = nodo2;
                }
                else
                {
                    _nodo.izquierda = nodo1;
                    _nodo.derecha = nodo2;
                }
                conexionbd.insertar(nuevoA, pregunta, resp);
            }

        }




    }

    }

