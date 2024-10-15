using System;
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

        public void AgregarMensajeTexto(MensajeTexto mensajeTexto)
        {
            mensajeTextoDAL.AgregarMensajeTexto(mensajeTexto);
        }

        public void EliminarMensajeTexto(int idMensaje)
        {
            mensajeTextoDAL.EliminarMensajeTexto(idMensaje);
        }

        public MensajeTexto ObtenerMensajeTextoPorId(int idMensaje)
        {
            return mensajeTextoDAL.ObtenerMensajeTextoPorId(idMensaje);
        }
    }
}
