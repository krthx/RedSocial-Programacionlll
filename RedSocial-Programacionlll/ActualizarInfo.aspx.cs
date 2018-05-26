using RedSocial_Programacionlll.Datos;
using RedSocial_Programacionlll.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedSocial_Programacionlll
{
    public partial class ActualizarInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtNombre.Text = ListaContext.Conectado.Nombre;
            TxtUsuario.Text = ListaContext.Conectado.NombreUsuario;
            TxtFecha.Text = ListaContext.Conectado.FechaNacimiento;
            TxtFoto.Text = ListaContext.Conectado.Foto;
        }

        protected void EliminarCuenta(object sender, EventArgs e)
        {
            ListaContext.Usuarios.Eliminar(ListaContext.Conectado);

            var seguidores = ListaContext.Conectado.Seguidores.EnumeratorList;
            var nodSeguidores = seguidores.Inicio;

            while (nodSeguidores != null)
            {
                var dato = ListaContext.Conectado.Seguidores.Buscar(nodSeguidores.Dato);
                var seguidor = (Usuario)dato;

                seguidor.Seguidos.Eliminar(ListaContext.Conectado.Id);

                var pubs = ListaContext.Conectado.Publicaciones;
                var nPubs = pubs.Primero;

                while(nPubs != null)
                {
                    var pub = (Publicacion)nPubs.Dato;

                    seguidor.Muro.Eliminar(pub);

                    nPubs = nPubs.Siguiente;
                }

                nodSeguidores = nodSeguidores.Enlace;

                ListaContext.Conectado.Seguidores.Eliminar(nodSeguidores.Dato);
            }

            var seguidos = ListaContext.Conectado.Seguidos.EnumeratorList;
            var nodSeguidos = seguidos.Inicio;

            while(nodSeguidos != null)
            {
                var dato = ListaContext.Conectado.Seguidores.Buscar(nodSeguidos.Dato);
                var seguido = (Usuario)dato;

                seguido.Seguidores.Eliminar(ListaContext.Conectado.Id);

                nodSeguidos = nodSeguidos.Enlace;

                ListaContext.Conectado.Seguidos.Eliminar(nodSeguidos.Dato);
            }

        }

        protected void ActualizarCambios(object sender, EventArgs e)
        {
            if (!TxtNombre.Text.Equals(""))
                ListaContext.Conectado.Nombre = TxtNombre.Text;

            if (!TxtFoto.Text.Equals(""))
                ListaContext.Conectado.Foto = TxtFoto.Text;

            if (!TxtFecha.Text.Equals(""))
                ListaContext.Conectado.FechaNacimiento = TxtFecha.Text;

            Response.Redirect("Tablero.aspx");
        }
    }
}