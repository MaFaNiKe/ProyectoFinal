using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class EvPostBLL
    {
        private readonly EvPostDAL evPostDAL;

        public EvPostBLL()
        {
            evPostDAL = new EvPostDAL();
        }

        public void InsertarEvPost(EvPost evPost)
        {
            evPostDAL.InsertarEvPost(evPost);
        }

        public void EliminarEvPost(int idPost, int idEvento)
        {
            evPostDAL.EliminarEvPost(idPost, idEvento);
        }

        public List<EvPost> ObtenerEvPosts()
        {
            return evPostDAL.ObtenerEvPosts();
        }
    }
}
