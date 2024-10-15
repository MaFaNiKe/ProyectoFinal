using System;

namespace Entidades
{
    public class EvGrupo
    {
        public int IdGrupo { get; set; }
        public int IdEvento { get; set; }

        // Relaciones
        public Grupo Grupo { get; set; } 
        public Evento Evento { get; set; } 

        // Constructor
        public EvGrupo() { }

        public EvGrupo(int idGrupo, int idEvento)
        {
            IdGrupo = idGrupo;
            IdEvento = idEvento;
        }

        // Métodos
        public override string ToString()
        {
            return $"Evento {Evento?.Nombre} - Grupo {Grupo?.Nombre}";
        }
    }
}
