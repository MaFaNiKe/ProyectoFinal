using System;

namespace Entidades
{
    public class UpvoteUp
    {
        public int IdPost { get; set; }
        public int IdPerfil { get; set; }

        // Relaciones
        public Post Post { get; set; }
        public Usuario Usuario { get; set; } 

        // Constructor
        public UpvoteUp() { }

        public UpvoteUp(int idPost, int idPerfil)
        {
            IdPost = idPost;
            IdPerfil = idPerfil;
        }

        // Métodos adicionales si es necesario
        public override string ToString()
        {
            return $"Upvote by User {IdPerfil} on Post {IdPost}";
        }
    }
}
