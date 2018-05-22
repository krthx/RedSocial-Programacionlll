﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial_Programacionlll.Datos
{
    public class Publicacion : Comparador
    {
        public Guid Id { get; set; }

        public String Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Publicacion(Boolean nuevo)
        {
            if (nuevo)
                Id = new Guid();
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
            Publicacion obj = (Publicacion)_q;

            return Id.CompareTo(obj.Id);
        }
    }
}
