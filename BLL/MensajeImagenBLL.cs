using System;
using DAL;
using Entidades;

namespace BLL
{
    public class MensajeImagenBLL
    {
        private readonly MensajeImagenDAL mensajeImagenDAL;

        public MensajeImagenBLL()
        {
            mensajeImagenDAL = new MensajeImagenDAL();
        }

        public void AgregarMensajeImagen(MensajeImagen mensajeImagen)
        {
            mensajeImagenDAL.AgregarMensajeImagen(mensajeImagen);
        }

        public void EliminarMensajeImagen(int idMensaje)
        {
            mensajeImagenDAL.EliminarMensajeImagen(idMensaje);
        }

        public MensajeImagen ObtenerMensajeImagenPorId(int idMensaje)
        {
            return mensajeImagenDAL.ObtenerMensajeImagenPorId(idMensaje);
        }
    }
}
