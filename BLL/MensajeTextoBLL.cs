using DAL;
using Entidades;

namespace BLL
{
    public class MensajeTextoBLL
    {
        private readonly MensajeTextoDAL mensajeTextoDAL;

        public MensajeTextoBLL()
        {
            mensajeTextoDAL = new MensajeTextoDAL();
        }

        // Método para agregar un mensaje de texto
        public void AgregarMensajeTexto(int idMensaje, string texto)
        {
            // Creamos el objeto MensajeTexto y lo pasamos a la capa DAL
            MensajeTexto mensajeTexto = new MensajeTexto
            {
                IdMensaje = idMensaje,
                Texto = texto
            };

            // Llamamos al método de DAL para agregar el mensaje
            mensajeTextoDAL.AgregarMensajeTexto(mensajeTexto);
        }

        // Método para eliminar un mensaje de texto
        public void EliminarMensajeTexto(int idMensaje)
        {
            mensajeTextoDAL.EliminarMensajeTexto(idMensaje);
        }

        // Método para obtener un mensaje de texto por su ID (ahora devuelve un objeto MensajeTexto)
        public MensajeTexto ObtenerMensajeTextoPorId(int idMensaje)
        {
            return mensajeTextoDAL.ObtenerMensajeTextoPorId(idMensaje);
        }
    }
}
