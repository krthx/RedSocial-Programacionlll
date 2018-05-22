using System;
using RedSocial_Programacionlll.Datos;
using RedSocial_Programacionlll.Source;

namespace RedSocial_Programacionlll
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CrearCuenta(object sender, EventArgs e)
        {
            var nombre = Nombre.Text;
            var usuario = Usuario.Text;
            var fecha = FechaNacimiento.Text;
            var contrasena = Contrasena.Text;

            try
            {
                ListaContext.Usuarios.Insertar(new Usuario(ListaContext.Nuevo) { Nombre = nombre, NombreUsuario = usuario, FechaNacimiento = fecha, Contrasena = contrasena });

                Response.Redirect("InicioSesion.aspx");
            }
            catch (Exception exc)
            {
                ErrorMessage.Text = "El usuario ya existe, intente otro";
            }
        }

        protected void IniciarSesion(object sender, EventArgs e)
        {            
            Response.Redirect("InicioSesion.aspx");
        }
    }
}