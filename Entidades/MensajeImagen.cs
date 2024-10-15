using System;

namespace Entidades
{
    public class MensajeImagen
    {
        public int IdMensaje { get; set; }
        public string Imagen { get; set; }

        // Relación
        public Mensaje Mensaje { get; set; }

        // Constructor
        public MensajeImagen() { }

        public MensajeImagen(int idMensaje, string imagen)
        {
            if (string.IsNullOrWhiteSpace(imagen))
                throw new ArgumentException("La imagen no puede ser nula o vacía.", nameof(imagen));

            IdMensaje = idMensaje;
            Imagen = imagen;
        }

        // Métodos
        public override string ToString()
        {
            return $"ID Mensaje: {IdMensaje}, Imagen: {Imagen}";
        }
    }
}
