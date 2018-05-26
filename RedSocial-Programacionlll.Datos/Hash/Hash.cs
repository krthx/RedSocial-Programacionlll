using System;

namespace RedSocial_Programacionlll.Datos
{
    public class Hash
    {
        public static readonly Int32 DefaultSize = 1027;

        Int32 Posicion;
        
        Object[] tabla = new Object[DefaultSize];

        public ListaEnlazada<Guid> EnumeratorList { get; set; }

        public Int32 Count { get; set; }

        public Hash()
        {
            Count = 0;
            EnumeratorList = new ListaEnlazada<Guid>();
        }

       private Int32 HashMod(Guid key)
        {
            var hash = key.GetHashCode();
            var pos = Math.Abs(hash % DefaultSize);

            return pos;
        }

        public void Insertar(Guid Clave, Object Dato)
        {
            if(!BuscarLocal(Clave))
            {
                Posicion = HashMod(Clave);

                if (tabla[Posicion] == null)
                    tabla[Posicion] = Dato;
                else
                {
                    var actual = tabla[Posicion];
                    ListaEnlazada<Usuario> colisiones = null;

                    if (typeof(Usuario).Equals(actual.GetType()))
                    {
                        colisiones = new ListaEnlazada<Usuario>();
                        colisiones.Agregar((Usuario)actual);
                    }
                    else
                        colisiones = (ListaEnlazada<Usuario>)actual;


                    colisiones.Agregar((Usuario)Dato);

                    tabla[Posicion] = colisiones;
                }

                EnumeratorList.Agregar(Clave);

                Count++;
            }
        }

        public void Eliminar(Guid Clave)
        {
            Posicion = HashMod(Clave);

            var actual = tabla[Posicion];

            if (typeof(Usuario).Equals(actual.GetType()))
            {
                tabla[Posicion] = null;
            }
            else
            {
                var colisiones = (ListaEnlazada<Usuario>)actual;

                colisiones.Eliminar(new Usuario(false) { Id = Clave });
            }

            Count--;
        }

        public object Buscar(Guid Clave)
        {
            Posicion = HashMod(Clave);

            return tabla[Posicion];
        }


        public bool BuscarLocal(Guid Id)
        {
            return EnumeratorList.Buscar(Id) != default(Guid);
        }
    }
}