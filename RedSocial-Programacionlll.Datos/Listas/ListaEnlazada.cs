namespace RedSocial_Programacionlll.Datos
{
    public class ListaEnlazada<T>
    {
         public NodoSimple<T> Inicio { get; set; }

        public ListaEnlazada()
        {
            Inicio = null;
        }

        public ListaEnlazada<T> Agregar(T t)
        {
            NodoSimple<T> nuevo = new NodoSimple<T>(t);
            nuevo.Enlace = Inicio;
            Inicio = nuevo;

            return this;
        }


        public bool Eliminar(T t)
        {
            NodoSimple<T> n = Inicio;

            while(n != null)
            {

                //if(n.Dato.Equals(t))
                //{
                //    n.
                //}

                n = n.Enlace;
            }

            return false;
        }

        public T Buscar(T t)
        {
            var a = Inicio;

            while(a != null)
            {
                if (a.Dato.Equals(t))
                    return a.Dato;

                a = a.Enlace;
            }

            return default(T);
        }
    }
}
