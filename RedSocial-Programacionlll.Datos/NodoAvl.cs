using System;

namespace RedSocial_Programacionlll.Datos
{

    public class NodoAvl : Nodo
    {

        public int fe;
        public NodoAvl(Object valor)
            : base(valor)
        {
            fe = 0;
        }

        public NodoAvl(Object valor, NodoAvl ramaIzdo, NodoAvl ramaDcho)
            : base(ramaIzdo, valor, ramaDcho)
        {
            fe = 0;
        }
    }
}
