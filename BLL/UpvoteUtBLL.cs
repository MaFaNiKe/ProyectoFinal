using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class UpvoteUtBLL
    {
        private readonly UpvoteUtDAL upvoteUtDAL;

        public UpvoteUtBLL()
        {
            upvoteUtDAL = new UpvoteUtDAL(); 
        }

        public void InsertarUpvote(UpvoteUt upvote)
        {
            upvoteUtDAL.InsertarUpvote(upvote);
        }

        public void EliminarUpvote(int idPerfil, int idTema)
        {
            upvoteUtDAL.EliminarUpvote(idPerfil, idTema);
        }

        public List<UpvoteUt> ObtenerUpvotesPorTema(int idTema)
        {
            return upvoteUtDAL.ObtenerUpvotesPorTema(idTema);
        }
    }
}
