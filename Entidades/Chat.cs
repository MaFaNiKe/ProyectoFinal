using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Chat : IEnumerable<Mensaje>
    {
        public int IdChat { get; set; }
        public bool ChatGrupal { get; set; }

        // Relaciones
        public ICollection<Mensaje> Mensajes { get; private set; } = new List<Mensaje>();

        // Constructores
        public Chat() { }

        public Chat(int idChat, bool chatGrupal)
        {
            if (idChat <= 0)
                throw new ArgumentOutOfRangeException(nameof(idChat), "El ID del chat debe ser mayor que cero.");

            IdChat = idChat;
            ChatGrupal = chatGrupal;
        }

        // Métodos
        public void AgregarMensaje(Mensaje mensaje)
        {
            if (mensaje == null)
                throw new ArgumentNullException(nameof(mensaje), "El mensaje no puede ser nulo.");

            Mensajes.Add(mensaje);
        }

        public void EliminarMensaje(Mensaje mensaje)
        {
            if (mensaje == null)
                throw new ArgumentNullException(nameof(mensaje), "El mensaje no puede ser nulo.");

            Mensajes.Remove(mensaje);
        }

        public int ContarMensajes()
        {
            return Mensajes.Count;
        }

        public bool ContieneMensaje(Mensaje mensaje)
        {
            return Mensajes.Contains(mensaje);
        }

        // Mostrar en la lista "Chat X", donde X es el IdChat
        public override string ToString()
        {
            return $"Chat {IdChat}";
        }

        // Implementación de IEnumerable para permitir la iteración sobre los mensajes
        public IEnumerator<Mensaje> GetEnumerator()
        {
            return Mensajes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
