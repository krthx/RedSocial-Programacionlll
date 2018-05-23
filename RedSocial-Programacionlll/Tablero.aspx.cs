using System;
using RedSocial_Programacionlll.Datos;
using RedSocial_Programacionlll.Source;

namespace RedSocial_Programacionlll
{
    public partial class Tablero : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = ListaContext.Conectado;
        }

        protected void AgregarPublicacion(object sender, EventArgs e)
        {            
            ListaContext.Conectado.Publicaciones.Agregar(new Publicacion(true) { Descripcion = TxtPublicacion.Text, FechaCreacion = DateTime.Now });

            TxtPublicacion.Text = String.Empty;
        }

        protected void Seguir(object sender, EventArgs e)
        {

        }

        protected void Eliminar(object sender, EventArgs e)
        {

        }

        protected void Buscar(object sender, EventArgs e)
        {

        }

        protected void ActualizarDatos(object sender, EventArgs e)
        {

        }

        protected void EliminarCuenta(object sender, EventArgs e)
        {
            
        }

        ListaDobleEnlazada ArmarMuro()
        {
            return null;
        }

        protected void EliminarPublicacion(object sender, EventArgs e)
        {

        }
    }
} 