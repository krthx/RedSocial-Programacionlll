using System;

namespace RedSocial_Programacionlll.Datos
{
    public class Hash
    {
        public static readonly Int32 M = 1027;

        Int32 Posicion;
        Object[] tabla = new Object[M];
        public Int32 Count { get; set; }

        public Hash()
        {
            Count = 0;
        }

        public Int32 HashMod(Int32 x)
        {
            return x % M;
        }

        public void Insertar(Object Dato, Int32 Clave)
        {
            Posicion = HashMod(Clave);
            tabla[Posicion] = Dato;

            Count++;
        }

        public void Eliminar(Int32 Clave)
        {
            Posicion = HashMod(Clave);
            tabla[Posicion] = null;

            Count--;
        }

        public object Buscar(Int32 Clave)
        {
            Posicion = HashMod(Clave);
            return tabla[Posicion];
        }

    }
}