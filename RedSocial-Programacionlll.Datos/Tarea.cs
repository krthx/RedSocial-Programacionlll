using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Tipos
{
    public class Tarea
    {
        public string Nombre { get; set; }
        public string Programador { get; set; }
        public double Avance { get; set; }
        public double Duracion { get; set; }

        public Tarea()
        {
            Nombre = String.Empty;
            Programador = String.Empty;
            Avance = 0;
            Duracion = 0;
        }

        public Tarea(string nombre, string programador, double avance, double duracion)
        {
            Nombre = nombre;
            Programador = programador;
            Avance = avance;
            Duracion = duracion;
        }
    }
}
