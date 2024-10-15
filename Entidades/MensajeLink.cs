using System;

namespace Entidades
{
    public class MensajeLink
    {
        public int IdMensaje { get; set; }
        public string Link { get; set; }

        // Relación
        public Mensaje Mensaje { get; set; }

        // Constructor
        public MensajeLink() { }

        public MensajeLink(int idMensaje, string link)
        {
            if (string.IsNullOrWhiteSpace(link))
                throw new ArgumentException("El enlace no puede ser nulo o vacío.", nameof(link));

            IdMensaje = idMensaje;
            Link = link;
        }

        // Métodos
        public override string ToString()
        {
            return $"ID Mensaje: {IdMensaje}, Link: {Link}";
        }
    }
}
