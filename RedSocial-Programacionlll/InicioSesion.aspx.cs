using System;
using System.Web.Script.Services;
using System.Web.Services;
using RedSocial_Programacionlll.Source;

namespace RedSocial_Programacionlll
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrarse(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void IniciarSesion(object sender, EventArgs e)
        {
            var usuario = Usuario.Text;
            var contrasena = Contrasena.Text;

            var resultado = ListaContext.ValidarCredenciales(usuario, contrasena);

            if (!resultado.Equals("Ok"))
                ErrorMessage.Text = resultado;
            else
                Response.Redirect("Tablero.aspx");
        }


        //[WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        //public static void VisitarPerfil(String Usr)
        //{
        //    ListaContext.BuscarPerfil(Usr);

        //    Response.Redirect("Perfil.aspx");
        //}
    }
}