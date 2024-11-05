using System;

namespace Entidades
{
    public class UpvoteUt
    {
        public int IdPerfil { get; set; }
        public int IdTema { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; } 
        public Tema Tema { get; set; }  

        // Constructor
        public UpvoteUt() { }

        public UpvoteUt(int idPerfil, int idTema)
        {
            IdPerfil = idPerfil;
            IdTema = idTema;
        }

        // Métodos adicionales
        public override string ToString()
        {
            return $"Upvote by User {IdPerfil} on Topic {IdTema}";
        }
    }
}
