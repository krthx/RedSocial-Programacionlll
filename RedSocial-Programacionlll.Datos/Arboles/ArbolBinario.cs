using System;
using System.Collections.Generic;

namespace RedSocial_Programacionlll.Datos
{
    [Serializable]
    public class ArbolBinario
    {
        public Nodo Raiz { get; set; }


        public ArbolBinario()
        {
            Raiz = null;
        }

        public ArbolBinario(Nodo raiz)
        {
            this.Raiz = raiz;
        }
        
        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
        bool EsVacio()
        {
            return Raiz == null;
        }

        public static Nodo NuevoArbol(Nodo ramaIzqda, Object dato, Nodo ramaDrcha)
        {
            return new Nodo(ramaIzqda, dato, ramaDrcha);
        }
        
        public static List<string[]> PreOrden(Nodo r)
        {
            if (r != null)
            {
                string[] valores = r.Dato.ToString().Split('+');

                if (valores != null)
                    proyectos.Add(valores);

                PreOrden(r.Izquierdo);

                PreOrden(r.Derecho);

                return proyectos;
            }

            return null;
        }

        public static List<string[]> proyectos = new List<string[]>();
        
        // Recorrido de un árbol binario en inorden
        public static List<string[]> InOrden(Nodo r)
        {
            if (r != null)
            {
                var a = InOrden(r.Izquierdo);
                
                var b = r.Dato.ToString().Split('+');

                if (b != null)
                    proyectos.Add(b);

                var c = InOrden(r.Derecho);

                return proyectos;
            }

            return null;
        }

        // Recorrido de un árbol binario en postorden
        public static List<string[]> PostOrden(Nodo r)
        {
            if (r != null)
            {
                PostOrden(r.Izquierdo);

                PostOrden(r.Derecho);

                string[] a = r.Dato.ToString().Split('+');

                if (a != null)
                    proyectos.Add(a);

                return proyectos;
            }
            
            return null;
        }

        //Devuelve el número de nodos que tiene el árbol
        public static int NumNodos(Nodo raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + NumNodos(raiz.Izquierdo) + NumNodos(raiz.Derecho);
        }
    }
}
