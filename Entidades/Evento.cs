using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        // Relaciones
        public ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

        // Constructor
        public Evento() { }

        public Evento(int idEvento, string nombre, string descripcion, DateTime fecha)
        {
            IdEvento = idEvento;
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
        }

        // Métodos
        public override string ToString()
        {
            return $"{Nombre} - {Descripcion} - {Fecha.ToShortDateString()}";
        }
    }
}
