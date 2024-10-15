using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class UpvoteUpBLL
    {
        private readonly UpvoteUpDAL upvoteUpDAL;

        public UpvoteUpBLL()
        {
            upvoteUpDAL = new UpvoteUpDAL();
        }

        public void InsertarUpvote(UpvoteUp upvote)
        {
            upvoteUpDAL.InsertarUpvote(upvote);
        }

        public void EliminarUpvote(int idPerfil, int idPost)
        {
            upvoteUpDAL.EliminarUpvote(idPerfil, idPost);
        }

        public List<UpvoteUp> ObtenerUpvotesPorPost(int idPost)
        {
            return upvoteUpDAL.ObtenerUpvotesPorPost(idPost);
        }
    }
}
