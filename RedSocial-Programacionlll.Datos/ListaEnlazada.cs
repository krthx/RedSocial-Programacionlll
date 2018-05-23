namespace RedSocial_Programacionlll.Datos
{
    public class ListaEnlazada
    {
         public NodoSimple Inicio { get; set; }

        public ListaEnlazada()
        {
            Inicio = null;
        }

        public ListaEnlazada Agregar(Usuario t)
        {
            NodoSimple nuevo = new NodoSimple(t);
            nuevo.Enlace = Inicio;
            Inicio = nuevo;

            return this;
        }

    }
}
