using System;

namespace RedSocial_Programacionlll.Datos
{
    [Serializable]
    public class Nodo
    {
        public Nodo()
        {
            Izquierdo = Derecho = null;
        }

        /// <summary>
        /// Método Constructor del nodo el cual recibe un valor y asign
        /// asigna nulos a los hijos
        /// </summary>
        /// <param name="valor">hhhhhhhhhhhhh</param>
        public Nodo(Object valor)
        {
            Dato = valor;
            Izquierdo = Derecho = null;
        }

        public Nodo(Nodo ramaIzdo, Object valor, Nodo ramaDcho)
        {
            this.Dato = valor;
            Izquierdo = ramaIzdo;
            Derecho = ramaDcho;
        }

        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        public Object Dato { get; set; }

        public String Valor {
            get
            {
                return Dato.ToString();
            }
        }
    }
}
