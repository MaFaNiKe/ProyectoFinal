using System;

namespace Entidades
{
    public class MensajeTexto
    {
        public int IdMensaje { get; set; }
        public string Texto { get; set; }

        // Relación
        public Mensaje Mensaje { get; set; }

        // Constructor
        public MensajeTexto() { }

        public MensajeTexto(int idMensaje, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("El texto no puede ser nulo o vacío.", nameof(texto));

            IdMensaje = idMensaje;
            Texto = texto;
        }

        // Métodos
        public override string ToString()
        {
            return $"ID Mensaje: {IdMensaje}, Texto: {Texto}";
        }
    }
}
