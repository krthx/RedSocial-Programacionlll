using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial_Programacionlll.Datos
{
    public class NodoListaEnlazada
    {
        public NodoListaEnlazada Anterior { get; set; }
        public NodoListaEnlazada Siguiente { get; set; }
        public object Dato { get; set; }

        public NodoListaEnlazada(Object valor)
        {
            Dato = valor;
            Anterior = Siguiente = null;
        }
        public NodoListaEnlazada(NodoListaEnlazada anterior, Object valor, NodoListaEnlazada siguiente)
        {
            this.Dato = valor;
            Anterior = anterior;
            Siguiente = siguiente;
        }
    }
}
