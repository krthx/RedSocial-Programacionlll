using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial_Programacionlll.Datos
{
    public class NodoListaEnlazada<T>
    {
        public NodoListaEnlazada<T> Anterior { get; set; }
        public NodoListaEnlazada<T> Siguiente { get; set; }
        public Object Dato { get; set; }

        public NodoListaEnlazada(Object valor)
        {
            Dato = valor;
            Anterior = Siguiente = null;
        }
        public NodoListaEnlazada(NodoListaEnlazada<T> anterior, Object valor, NodoListaEnlazada<T> siguiente)
        {
            this.Dato = valor;
            Anterior = anterior;
            Siguiente = siguiente;
        }
    }
}
