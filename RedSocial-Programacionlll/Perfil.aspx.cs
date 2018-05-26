using System;
using RedSocial_Programacionlll.Datos;
using RedSocial_Programacionlll.Source;

namespace RedSocial_Programacionlll
{
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = ListaContext.Visitar;
        }

        protected void Regresar(object sender, EventArgs e)
        {            
            Response.Redirect("Tablero.aspx");
        }

        protected void SeguirUsuario(object sender, EventArgs e)
        {
            var p = ListaContext.Visitar;
            var c = ListaContext.Conectado;

            ListaContext.Conectado.Seguidos.Insertar(p.Id, p);
            ListaContext.Visitar.Seguidores.Insertar(c.Id, c);
        }
    }
}