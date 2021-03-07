using System;
using System.Collections.Generic;
using System.Text;

namespace Juego_Adivina_Animal_P1P3.Clases.ArbolBinario
{
    class arbolBinario
    {
        protected Nodo raiz;

        public arbolBinario()
        {
            raiz = null; 
        }

        public arbolBinario(Nodo valorRaiz)
        {
            this.raiz = valorRaiz;
        }

        public Nodo raizArbol()
        {
            return raiz;
        }

        bool esVacio()
        {
            return raiz == null;
        }

        public static Nodo nuevoArbol(Nodo ramaIzqda,object dato, Nodo ramaDrcha)
        {
            return new Nodo(ramaIzqda, dato, ramaDrcha);
        }

    }
}
