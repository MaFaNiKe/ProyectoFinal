using System;
using DAL;
using Entidades;

namespace BLL
{
    public class PostTextoBLL
    {
        private readonly PostTextoDAL postTextoDAL;

        public PostTextoBLL()
        {
            postTextoDAL = new PostTextoDAL();
        }

        public void AgregarPostTexto(PostTexto postTexto)
        {
            postTextoDAL.AgregarPostTexto(postTexto);
        }

        public void EliminarPostTexto(int idPost)
        {
            postTextoDAL.EliminarPostTexto(idPost);
        }

        public PostTexto ObtenerPostTextoPorId(int idPost)
        {
            return postTextoDAL.ObtenerPostTextoPorId(idPost);
        }
    }
}
