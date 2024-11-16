using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        public string Nombre { get; set; }
        public bool textoPublico { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public Usuario Creador { get; set; }
        public ICollection<Usuario> Miembros { get; set; } = new List<Usuario>();
        public ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();

        // Constructores
        public Grupo() { }

        public Grupo(int idGrupo, string nombre, bool textoPublico, string comentarios, DateTime fechaCreacion, Usuario creador)
        {
            IdGrupo = idGrupo;
            Nombre = nombre;
            textoPublico = textoPublico;
            Comentarios = comentarios;
            FechaCreacion = fechaCreacion;
            Creador = creador;
        }

        // Métodos
        public void AgregarMiembro(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (Miembros.Contains(usuario))
                throw new InvalidOperationException("El usuario ya es miembro del grupo.");

            Miembros.Add(usuario);
        }

        public void EliminarMiembro(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (!Miembros.Contains(usuario))
                throw new InvalidOperationException("El usuario no es miembro del grupo.");

            if (usuario == Creador)
            {
                EliminarGrupo(); 
                return;
            }

            Miembros.Remove(usuario);
        }

        public void AgregarMensaje(Mensaje mensaje)
        {
            if (mensaje == null)
                throw new ArgumentNullException(nameof(mensaje));

            Mensajes.Add(mensaje);
        }

        public void EliminarMensaje(Mensaje mensaje)
        {
            if (mensaje == null)
                throw new ArgumentNullException(nameof(mensaje));

            Mensajes.Remove(mensaje);
        }

        private void EliminarGrupo()
        {
            throw new InvalidOperationException("El grupo ha sido eliminado porque el creador salió.");
        }

        public override string ToString()
        {
            return $"{Nombre} - Created by {Creador?.Nombre}";
        }
    }
}
