using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Dynamic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
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

            //Page.GetPostBackEventReference(hiddenButton);
        }

        protected void AgregarPublicacion(object sender, EventArgs e)
        {
            var publicacion = new Publicacion(true) { Descripcion = TxtPublicacion.Text, FechaCreacion = DateTime.Now, Usuario = ListaContext.Conectado.NombreUsuario, Nombre = ListaContext.Conectado.Nombre };

            ListaContext.Conectado.Publicaciones.Agregar(publicacion);
            ListaContext.Conectado.Muro.Agregar(publicacion);

            var seg = ListaContext.Conectado.Seguidores.EnumeratorList;
            var Nod = seg.Inicio;

            while(Nod != null)
            {
                var s = ListaContext.Conectado.Seguidores.Buscar(((Guid)Nod.Dato));
                ((Usuario)s).Muro.Agregar(publicacion);

                Nod = Nod.Enlace;
            }

            TxtPublicacion.Text = String.Empty;
        }

        protected void SeguirPerfil(object sender, EventArgs e)
        {

        }

        protected void EliminarPerfil(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static String BuscarPerfil(String Busqueda)
        {
            var coincidencias = ListaContext.BuscarCoincidencias(Busqueda);

            var c = coincidencias.Inicio;
            object[] json = new object[0];

            var count = 0;

            while(c != null)
            {
                dynamic it = new ExpandoObject();
                var dat = c.Dato;

                var resultado = ListaContext.Conectado.Seguidos.BuscarLocal(dat.Id);

                var me = ListaContext.Conectado.Id.CompareTo(dat.Id);
                it.Categoria = (resultado == false) ? "Otros" : "Seguidos";

                if (me == 0)
                    it.Categoria = "Yo";

                Array.Resize(ref json, json.Length + 1);
                json[json.Length - 1] = new { dat.NombreUsuario, dat.Foto, it.Categoria };
                count++;

                c = c.Enlace;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(json);
        }
        
        protected void ActualizarDatos(object sender, EventArgs e)
        {
            Response.Redirect("ActualizarInfo.aspx");
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static void VisitarPerfil(String Usr)
        {
            ListaContext.BuscarPerfil(Usr);
        }
    }
} 