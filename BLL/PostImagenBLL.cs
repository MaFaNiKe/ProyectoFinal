using System;
using DAL;
using Entidades;

namespace BLL
{
    public class PostImagenBLL
    {
        private readonly PostImagenDAL postImagenDAL;

        public PostImagenBLL()
        {
            postImagenDAL = new PostImagenDAL(); 
        }

        public void AgregarPostImagen(PostImagen postImagen)
        {
            postImagenDAL.AgregarPostImagen(postImagen);
        }

        public void EliminarPostImagen(int idPost)
        {
            postImagenDAL.EliminarPostImagen(idPost);
        }

        public PostImagen ObtenerPostImagenPorId(int idPost)
        {
            return postImagenDAL.ObtenerPostImagenPorId(idPost);
        }
    }
}
