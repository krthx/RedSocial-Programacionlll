using RedSocial_Programacionlll.Datos;
using RedSocial_Programacionlll.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Intento2
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LeerArchivo(object sender, EventArgs e)
        {
            // conversion del objeto a un elemento de tipo boton
            Button abrir = sender as Button;
            XmlTextReader xmlTextReader = null;

            //w
            if (abrir.ID == "BtnTuits") 
            {
                xmlTextReader = new XmlTextReader("C:\\proyecto\\Tuits_usuarios.xml");
            }
            else if (abrir.ID=="BtnUsuarios")
            {
                xmlTextReader = new XmlTextReader("C:\\proyecto\\Usuarios.xml");
            }
            else
            {
                xmlTextReader = new XmlTextReader("C:\\proyecto\\Usuarios_seguidos.xml");
            }

            richTexbox.InnerText = String.Empty;
            String ultimaEtiqueta = "";
            List<Tuits> twits = new List<Tuits>();
            List<Usuario> usuario = new List<Usuario>();
            List<Seguidos>seguidos = new List<Seguidos>();


            while (xmlTextReader.Read())
            {
                if (xmlTextReader.NodeType == XmlNodeType.Element)
                {
                    richTexbox.InnerText += (new String(' ', xmlTextReader.Depth * 3) + "<" + xmlTextReader.Name + ">");
                    ultimaEtiqueta = xmlTextReader.Name;
                    continue;
                }
                if (xmlTextReader.NodeType == XmlNodeType.Text)
                {
                    richTexbox.InnerText += xmlTextReader.ReadContentAsString() + "</" + ultimaEtiqueta + ">";
                }
                else
                    richTexbox.InnerText += "\r";
            }

        }

        protected void btnUsuario(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"C:\\Users\\bpaniagua\\Downloads\\Usuarios.xml");
            XmlNodeList listaNodos = xmlDocument.GetElementsByTagName("DATA_RECORD");

            foreach (XmlElement control in listaNodos)
            {
                var NickName = control.GetElementsByTagName("NICK_NAME")?.Item(0)?.InnerText;
                var Nombre = control.GetElementsByTagName("NOMBRE")?.Item(0)?.InnerText;
                var Fecha = control.GetElementsByTagName("FECHA")?.Item(0)?.InnerText;
                var Foto = control.GetElementsByTagName("FOTO")?.Item(0)?.InnerText;


                var FechaD = Convert.ToDateTime(Fecha);
                //usuarios.Add(new Usuario(true) { Nombre = Nombre, NombreUsuario = NickName, FechaNacimiento = Fecha, Foto = Foto });
                ListaContext.Usuarios.Insertar(new Usuario(true) { Nombre = Nombre, NombreUsuario = NickName, FechaNacimiento = Fecha, Foto = Foto, Contrasena = "Default" });
            }

            richTexbox.InnerText = "ok" + usuarios.Count;
        }

        protected void btnSeguidos(object sender, EventArgs e)
        {
            List<Seguidos> seguidos = new List<Seguidos>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"C:\\Users\\bpaniagua\\Downloads\\Usuarios_seguidos.xml");
            XmlNodeList listaNodos = xmlDocument.GetElementsByTagName("DATA_RECORD");

            foreach (XmlElement control in listaNodos)
            {
                var Usuario = control.GetElementsByTagName("USUARIO")?.Item(0)?.InnerText;
                var UsuarioSeguido = control.GetElementsByTagName("USUARIO_SEGUIDO")?.Item(0)?.InnerText;


                //seguidos.Add(new Seguidos() { NombreUsuario = Usuario,  UsuarioSeguido = UsuarioSeguido });
                var seguido = ListaContext.Usuarios.Buscar(new Usuario(false) { NombreUsuario = UsuarioSeguido });
                var principal = ListaContext.Usuarios.Buscar(new Usuario(false) { NombreUsuario = Usuario });

                if(principal != null && seguido != null)
                {
                    var s = (Usuario)seguido;
                    var p = (Usuario)principal;

                    p.Seguidos.Insertar(s.Id, s);

                    s.Seguidores.Insertar(p.Id, p);
                }
            }
            richTexbox.InnerText = "ok" + seguidos.Count;
        }

        protected void btnTuits(object sender, EventArgs e)
        {
            List<Tuits> tuits = new List<Tuits>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"C:\\Users\\bpaniagua\\Downloads\\Tuits_usuarios.xml");
            XmlNodeList listaNodos = xmlDocument.GetElementsByTagName("DATA_RECORD");

            foreach (XmlElement control in listaNodos)
            {
                var NickName = control.GetElementsByTagName("NICK_NAME")?.Item(0)?.InnerText;
                var Tuit = control.GetElementsByTagName("TUIT")?.Item(0)?.InnerText;

                //tuits.Add(new Tuits() { NombreUsuario = NickName, Descripcion = Tuit });

                //var seguido = ListaContext.Usuarios.Buscar(new Usuario(false) { NombreUsuario = UsuarioSeguido });
                var principal = ListaContext.Usuarios.Buscar(new Usuario(false) { NombreUsuario = NickName });

                if (principal != null)
                {
                    var u = (Usuario)principal;
                    var publicacion = new Publicacion(true) { Descripcion = Tuit, FechaCreacion = DateTime.Now, Usuario = u.NombreUsuario, Nombre = u.Nombre };

                    u.Publicaciones.Agregar(publicacion);

                    var iterator = u.Seguidores.EnumeratorList;
                    u.Muro.Agregar(publicacion);

                    var Nod = iterator.Inicio;

                    while (Nod != null)
                    {
                        var s = ListaContext.Conectado.Seguidores.Buscar(((Guid)Nod.Dato));
                        ((Usuario)s).Muro.Agregar(publicacion);

                        Nod = Nod.Enlace;
                    }

                }
            }
            richTexbox.InnerText = "ok" + tuits.Count;
        }

    }
    
}