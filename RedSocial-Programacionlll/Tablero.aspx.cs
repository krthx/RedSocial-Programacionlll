using System;
using System.Dynamic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
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

        protected void SeguirPerfil(object sender, EventArgs e)
        {

        }

        protected void EliminarPerfil(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static String BuscarPerfil(String Busqueda)
        {
            var coincidencias = ListaContext.BuscarCoincidencias(Busqueda);

            var c = coincidencias.Inicio;
            dynamic json = new ExpandoObject();
            var count = 0;

            while(c != null)
            {
                dynamic it = new ExpandoObject();
                var dat = c.Dato;

                it.Amigos = ListaContext.Conectado.Seguidos.BuscarLocal(dat.Id);
                it.NombreUsuario = dat.NombreUsuario;
                it.Foto = dat.Foto;

                json[count] = it;
                count++;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(json);
        }

        [WebMethod]
        public static String BuscarPerfil2()
        {
            return "Ok";
        }

        [WebMethod]
        public String BuscarPerfil3()
        {
            return "Ok";
        }

        protected void ActualizarDatos(object sender, EventArgs e)
        {

        }

        protected void EliminarCuenta(object sender, EventArgs e)
        {
            
        }

        ListaDobleEnlazada<Publicacion> ArmarMuro()
        {
            return null;
        }

        protected void EliminarPublicacion(object sender, EventArgs e)
        {

        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            ListaContext.Conectado = null;

            Response.Redirect("InicioSesion.aspx");
        }

        protected void VisitarPerfil(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            String Usr = lnk.Attributes["data-usr"].ToString();

            ListaContext.BuscarPerfil(Usr);

            Response.Redirect("Perfil.aspx");

        }
    }
} 