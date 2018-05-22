using System;

namespace RedSocial_Programacionlll.Datos
{
    public class Usuario : Comparador
    {
        public Guid Id { get; set; }
        public String NombreUsuario { get; set; }

        public String Nombre { get; set; }

        public String FechaNacimiento { get; set; }

        public DateTime Creacion { get; set; }

        public String Foto { get; set; }

        public String Contrasena { get; set; }

        public Hash Seguidores { get; set; }

        public Hash Seguidos { get; set; }

        public ListaDobleEnlazada Publicaciones { get; set; }

        public Usuario(Boolean nuevo)
        {
            if (nuevo)
            {
                Id = new Guid();
                Seguidores = new Hash();
                Seguidos = new Hash();
                Publicaciones = new ListaDobleEnlazada();
            }
                
        } 

        bool Comparador.IgualQue(object q)
        {
            return Comparar(q) == 0;
        }
        
        bool Comparador.MayorQue(object q)
        {
            return Comparar(q) > 0;
        }
        
        bool Comparador.MenorQue(object q)
        {
            return Comparar(q) < 0;
        }

        Int32 Comparar(object _q)
        {
            Usuario obj = (Usuario)_q;

            return NombreUsuario.CompareTo(obj.NombreUsuario);
        }
    }
}
