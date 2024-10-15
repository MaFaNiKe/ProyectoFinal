using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tema
    {
        public int IdTema { get; set; }
        public string NombreTema { get; set; }

        // Constructor por defecto
        public Tema()
        {
        }

        // Constructor con parámetros
        public Tema(int idTema, string nombreTema)
        {
            IdTema = idTema;
            NombreTema = nombreTema;
        }

        // Métodos adicionales
        public void ActualizarNombreTema(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre del tema no puede estar vacío.", nameof(nuevoNombre));

            NombreTema = nuevoNombre;
        }

        public override string ToString()
        {
            return $"Tema {IdTema}: {NombreTema}";
        }
    }
}
