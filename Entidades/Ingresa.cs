using System;

namespace Entidades
{
    public class Ingresa
    {
        public int IdPerfil { get; set; }
        public int IdGrupo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Rol { get; set; } 

        // Relaciones
        public Usuario Usuario { get; set; } 
        public Grupo Grupo { get; set; } 

        // Constructor
        public Ingresa() { }

        public Ingresa(int idPerfil, int idGrupo, DateTime fechaIngreso, string rol = "miembro")
        {
            IdPerfil = idPerfil;
            IdGrupo = idGrupo;
            FechaIngreso = fechaIngreso;
            Rol = rol;
        }

        // Métodos
        public override string ToString()
        {
            return $"{Usuario?.Nombre} {Usuario?.Apellido} - Grupo {Grupo?.Nombre} - Rol: {Rol}";
        }
    }
}
