using System;
using System.Collections.Generic; // Agrega esto para usar List<>
using Entidades;
using DAL;

namespace BLL
{
    public class MensajeBLL
    {
        private readonly MensajeDAL mensajeDAL;  // Cambiado a readonly

        public MensajeBLL()
        {
            mensajeDAL = new MensajeDAL();  // Inicialización del DAL
        }

        public void AgregarMensaje(Mensaje mensaje)
        {
            if (mensaje == null)
                throw new ArgumentNullException(nameof(mensaje), "El mensaje no puede ser nulo.");

            mensajeDAL.AgregarMensaje(mensaje);
        }

        public void EliminarMensaje(int idMensaje)
        {
            if (idMensaje <= 0)
                throw new ArgumentException("El ID del mensaje debe ser mayor que cero.", nameof(idMensaje));

            mensajeDAL.EliminarMensaje(idMensaje);
        }

        public Mensaje ObtenerMensajePorId(int idMensaje)
        {
            if (idMensaje <= 0)
                throw new ArgumentException("El ID del mensaje debe ser mayor que cero.", nameof(idMensaje));

            return mensajeDAL.ObtenerMensajePorId(idMensaje);
        }

        // Método opcional para obtener todos los mensajes
        public List<Mensaje> ObtenerTodosLosMensajes()
        {
            return mensajeDAL.ObtenerTodosLosMensajes();
        }
    }
}
