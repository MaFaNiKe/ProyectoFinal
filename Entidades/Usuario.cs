using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Usuario
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNac { get; set; }  // Usa DateTime para almacenar la fecha
        public TipoUsuarioEnum TipoUsuario { get; set; }

        // Relaciones
        public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<UpvoteUp> UpvotesPost { get; set; } = new List<UpvoteUp>();
        public ICollection<Ingresa> Grupos { get; set; } = new List<Ingresa>();
        public ICollection<UpvoteUt> UpvotesTema { get; set; } = new List<UpvoteUt>();

        // Constructores
        public Usuario() { }

        public Usuario(int idPerfil, string nombre, string apellido, string correo, string contrasena, DateTime fechaNac, TipoUsuarioEnum tipoUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            if (!EsCorreoValido(correo))
                throw new ArgumentException("El correo no es válido.", nameof(correo));
            if (string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(contrasena));

            IdPerfil = idPerfil;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Contrasena = contrasena; // Considera hacer hash aquí
            FechaNac = fechaNac.Date;  // Asegúrate de usar solo la fecha
            TipoUsuario = tipoUsuario;
        }

        public void ActualizarPerfil(string nombre, string apellido, string correo, string contrasena, DateTime fechaNac, TipoUsuarioEnum tipoUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            if (!EsCorreoValido(correo))
                throw new ArgumentException("El correo no es válido.", nameof(correo));
            if (string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(contrasena));

            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Contrasena = contrasena; // Considera hacer hash aquí
            FechaNac = fechaNac.Date;  // Solo la fecha
            TipoUsuario = tipoUsuario;
        }

        // Métodos para manejar relaciones
        public void AgregarPost(Post post) => Posts.Add(post);
        public void EliminarPost(Post post) => Posts.Remove(post);

        public void AgregarTelefono(Telefono telefono) => Telefonos.Add(telefono);
        public void EliminarTelefono(Telefono telefono) => Telefonos.Remove(telefono);

        public void AgregarUpvotePost(UpvoteUp upvote) => UpvotesPost.Add(upvote);
        public void EliminarUpvotePost(UpvoteUp upvote) => UpvotesPost.Remove(upvote);

        public void AgregarGrupo(Ingresa grupo) => Grupos.Add(grupo);
        public void EliminarGrupo(Ingresa grupo) => Grupos.Remove(grupo);

        public void AgregarUpvoteTema(UpvoteUt upvote) => UpvotesTema.Add(upvote);
        public void EliminarUpvoteTema(UpvoteUt upvote) => UpvotesTema.Remove(upvote);

        public string ObtenerInformacionBasica() => $"ID: {IdPerfil}, Nombre: {Nombre} {Apellido}, Correo: {Correo}, Tipo: {TipoUsuario}";

        // Método para validar correo
        private bool EsCorreoValido(string correo)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(correo);
        }
    }

    public class UsuarioDTO
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
    }

    public enum TipoUsuarioEnum
    {
        comun,
        desarrollador
    }
}
