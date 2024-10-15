using System;

namespace Entidades
{
    public class Mensaje
    {
        // Propiedades
        public int IdMensaje { get; set; }
        public int IdChat { get; set; }
        public int IdPerfilEnvia { get; set; }
        public int IdPerfilRecibe { get; set; }
        public DateTime FechaHora { get; set; }

        // Propiedades específicas
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public string Link { get; set; }

        // Tipo de mensaje
        public MensajeTipo Tipo { get; set; }

        // Relaciones
        public Chat Chat { get; set; }
        public Usuario PerfilEnvia { get; set; }
        public Usuario PerfilRecibe { get; set; }

        // Enumeración para definir el tipo de mensaje
        public enum MensajeTipo
        {
            Texto,
            Imagen,
            Link
        }

        // Constructor
        public Mensaje() { }

        public Mensaje(int idMensaje, int idChat, int idPerfilEnvia, int idPerfilRecibe, DateTime fechaHora, MensajeTipo tipo, string texto = null, string imagen = null, string link = null)
        {
            if (idPerfilEnvia <= 0)
                throw new ArgumentException("El ID del perfil que envía debe ser mayor que cero.", nameof(idPerfilEnvia));

            if (idPerfilRecibe <= 0)
                throw new ArgumentException("El ID del perfil que recibe debe ser mayor que cero.", nameof(idPerfilRecibe));

            if (fechaHora == default)
                throw new ArgumentException("La fecha y hora del mensaje no puede ser la fecha por defecto.", nameof(fechaHora));

            if (idPerfilEnvia == idPerfilRecibe)
                throw new ArgumentException("El perfil que envía no puede ser el mismo que el perfil que recibe.");

            IdMensaje = idMensaje;
            IdChat = idChat;
            IdPerfilEnvia = idPerfilEnvia;
            IdPerfilRecibe = idPerfilRecibe;
            FechaHora = fechaHora;
            Tipo = tipo;
            Texto = texto;
            Imagen = imagen;
            Link = link;
        }

        // Métodos
        public override string ToString()
        {
            return $"Mensaje ID: {IdMensaje}, Chat ID: {IdChat}, Enviado por: {IdPerfilEnvia}, Recibido por: {IdPerfilRecibe}, Fecha: {FechaHora}, Tipo: {Tipo}, Texto: {Texto}, Imagen: {Imagen}, Link: {Link}";
        }
    }
}
