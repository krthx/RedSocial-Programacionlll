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

        public ListaDobleEnlazada<Publicacion> Publicaciones { get; set; }

        public ListaDobleEnlazada<Publicacion> Muro { get; set; }

        public Usuario(Boolean nuevo)
        {
            if (nuevo)
                Id = Guid.NewGuid();
                
            if(Seguidores == null)
                Seguidores = new Hash();

            if (Seguidos == null)
                Seguidos = new Hash();

            if (Publicaciones == null)
                Publicaciones = new ListaDobleEnlazada<Publicacion>();

            if (Muro == null)
                Muro = new ListaDobleEnlazada<Publicacion>();
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
        bool Comparador.Contains(object q)
        {
            return NombreUsuario.Contains(Convertir(q).NombreUsuario);
        }

        Int32 Comparar(object _q)
        {
            return NombreUsuario.CompareTo(Convertir(_q).NombreUsuario);
        }

        Usuario Convertir(object _q)
        {
            return (Usuario)_q;
        }
    }
}
