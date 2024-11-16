using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Likes
    {
        public int Id { get; set; }          // ID único del like
        public int IdPost { get; set; }      // ID del post al que se le dio like
        public int IdPerfil { get; set; }     // ID del perfil que dio like

        // Constructor
        public Likes(int idPost, int idPerfil)
        {
            IdPost = idPost;
            IdPerfil = idPerfil;
        }

        // Constructor para crear desde la base de datos
        public Likes(int id, int idPost, int idPerfil)
        {
            Id = id;
            IdPost = idPost;
            IdPerfil = idPerfil;
        }

        public override string ToString()
        {
            return $"Like: Id={Id}, IdPost={IdPost}, IdPerfil={IdPerfil}";
        }
    }
}
