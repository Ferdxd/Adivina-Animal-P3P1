using System;
using System.Collections.Generic;
using System.Text;

namespace Juego_Adivina_Animal_P1P3.Clases.ArbolBinario
{
    class Nodo
    {
        public object dato;
        public Nodo izquierda;
        public Nodo derecha;

        public Nodo(object valor)
        {
            dato = valor;
            izquierda = null;
            derecha = null;
        }

        public Nodo(Nodo ramaIzquierda,object valor,Nodo ramaDerecha)
        {
            dato = valor;
            izquierda = ramaIzquierda;
            derecha = ramaDerecha;
        }

        public object valorNodo()
        {
            return dato;
        }

        public Nodo subarbolDerecho()
        {
            return derecha;
        }

        public Nodo subarbolIzquierdo()
        {
            return izquierda;
        }

        public void nuevoValor(object nv)
        {
            dato = nv;
        }

        public void ramaIzquierda(Nodo n)
        {
            izquierda = n;
        }

        public void ramaDerecha(Nodo n)
        {
             derecha= n;
        }


        public void visitar()
        {
            Console.WriteLine(dato + "<-> ");
        }

    }
}
