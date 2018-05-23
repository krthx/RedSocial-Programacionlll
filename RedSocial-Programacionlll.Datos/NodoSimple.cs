namespace RedSocial_Programacionlll.Datos
{
    public class NodoSimple
    {
        public Usuario Usuario { get; set; }
        public NodoSimple Enlace { get; set; }

        public NodoSimple(Usuario t)
        {
            Enlace = null;
            Usuario = t;
        }

        public NodoSimple(Usuario t, NodoSimple n)
        {
            Usuario = t;
            Enlace = n;
        }
    }
}
