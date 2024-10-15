using System;
using DAL;
using Entidades;

namespace BLL
{
    public class PostBLL
    {
        private readonly PostDAL postDAL;

        public PostBLL()
        {
            postDAL = new PostDAL();
        }

        public void AgregarPost(Post post)
        {
            postDAL.AgregarPost(post);
        }

        public void EliminarPost(int idPost)
        {
            postDAL.EliminarPost(idPost);
        }

        public Post ObtenerPostPorId(int idPost)
        {
            return postDAL.ObtenerPostPorId(idPost);
        }
    }
}
