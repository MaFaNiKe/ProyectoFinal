using System;

namespace Entidades
{
    public class EvPost
    {
        public int IdPost { get; set; }
        public int IdEvento { get; set; }

        // Relaciones
        public Post Post { get; set; } // Relación con Post
        public Evento Evento { get; set; } // Relación con Evento

        // Constructor
        public EvPost() { }

        public EvPost(int idPost, int idEvento)
        {
            IdPost = idPost;
            IdEvento = idEvento;
        }

        // Método para mostrar información de la relación evento-post
        public override string ToString()
        {
            return $"Post {IdPost} en Evento {IdEvento}";
        }
    }
}
