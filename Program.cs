using Juego_Adivina_Animal_P1P3.Clases.BaseDatos;
using Juego_Adivina_Animal_P1P3.Clases.Juego;
using System;
using System.Collections.Generic;
using System.Data;

namespace Juego_Adivina_Animal_P1P3
{
    class Program
    {
        static void Main(string[] args)
        {

             juegoAnimales();
            

        }


        public static void juegoAnimales()
        {
            int option;
            Boolean salir = false;
            Boolean otrojuego = true;
            AdivinaAnimal juego = new AdivinaAnimal();
            Boolean load = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;  
                Console.WriteLine("1. Juguemos a adivinar animales");
                Console.WriteLine("2.Mostrar Grafica Del Arbol");
                Console.WriteLine("3. Salir");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        do
                        {
                            load = juego.jugar(load);

                        
                            Console.WriteLine("jugamos otra vez?");
                            otrojuego = juego.respuesta();
                        } while (otrojuego); break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        juego.graphicArbol();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Esta Seguro Que Desea Salir?");
                        salir = juego.respuesta();
                        
                        break;

                }
                Console.Clear();
            } while (salir!=true);

        }

    }
}
