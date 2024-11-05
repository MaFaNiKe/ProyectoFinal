using System;
using DAL;
using Entidades;

namespace BLL
{
    public class PostLinkBLL
    {
        private readonly PostLinkDAL postLinkDAL;

        public PostLinkBLL()
        {
            postLinkDAL = new PostLinkDAL(); 
        }

        public void AgregarPostLink(PostLink postLink)
        {
            postLinkDAL.AgregarPostLink(postLink);
        }

        public void EliminarPostLink(int idPost)
        {
            postLinkDAL.EliminarPostLink(idPost);
        }

        public PostLink ObtenerPostLinkPorId(int idPost)
        {
            return postLinkDAL.ObtenerPostLinkPorId(idPost);
        }
    }
}
