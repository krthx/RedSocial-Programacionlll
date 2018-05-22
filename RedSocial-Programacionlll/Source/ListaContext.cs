using RedSocial_Programacionlll.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedSocial_Programacionlll.Source
{
    public class ListaContext
    {
        public const Boolean Nuevo = true;
        public const Boolean Busqueda = false;
        public static Usuario Conectado { get; set; }

        public static ArbolAVL Ctx = null;

        public static readonly object Padlock = new object();

        public static ArbolAVL Usuarios
        {
            get
            {
                lock(Padlock)
                {
                    if (Ctx == null)
                        Ctx = new ArbolAVL();

                    return Ctx;
                }
            }
        }

        public static String ValidarCredenciales(String usuario, String contrasena)
        {
            var resultado = Usuarios.Buscar(new Usuario(ListaContext.Busqueda) { NombreUsuario = usuario });

            if (resultado == null)
                return "El usuario no registrado";

            var conectado = (Usuario)resultado;

            if (!conectado.Contrasena.Equals(contrasena))
                return "Contraseña incorrecta, intente de nuevo";

            Conectado = conectado;

            return "Ok";
        }

    }
}