using System;
using DAL;
using Entidades;

namespace BLL
{
    public class MensajeLinkBLL
    {
        private readonly MensajeLinkDAL mensajeLinkDAL;

        public MensajeLinkBLL()
        {
            mensajeLinkDAL = new MensajeLinkDAL();
        }

        public void AgregarMensajeLink(MensajeLink mensajeLink)
        {
            mensajeLinkDAL.AgregarMensajeLink(mensajeLink);
        }

        public void EliminarMensajeLink(int idMensaje)
        {
            mensajeLinkDAL.EliminarMensajeLink(idMensaje);
        }

        public MensajeLink ObtenerMensajeLinkPorId(int idMensaje)
        {
            return mensajeLinkDAL.ObtenerMensajeLinkPorId(idMensaje);
        }
    }
}
