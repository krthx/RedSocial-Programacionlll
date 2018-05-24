namespace RedSocial_Programacionlll.Datos
{
    public class NodoSimple<T>
    {
        public T Dato { get; set; }
        public NodoSimple<T> Enlace { get; set; }

        public NodoSimple(T t)
        {
            Enlace = null;
            Dato = t;
        }

        public NodoSimple(T t, NodoSimple<T> n)
        {
            Dato = t;
            Enlace = n;
        }
    }
}
