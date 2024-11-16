using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidades
{
    public class Post
    {
        public int IdPost { get; set; }
        public int IdPerfil { get; set; }
        public string NombreUsuario { get; set; }
        public string Texto { get; set; }  // Campo de texto agregado
        public DateTime Fecha { get; set; }
        public int Likes { get; set; }     // Contador de likes agregado
        public string textoImagen { get; set; }
        public string textoLink { get; set; }

         List<int> likesUsuarios = new List<int>();// En este list se guardarán los id de los usuarios que han dado like al post

        // Nueva propiedad para almacenar los IDs de usuarios que han dado like
        public List<int> LikesUsuarios { get; set; } = new List<int>();

        // Relaciones
        public Usuario Usuario { get; set; }
        public ICollection<PostImagen> PostImagens { get; set; } = new List<PostImagen>();
        public ICollection<PostLink> PostLinks { get; set; } = new List<PostLink>();
        public ICollection<UpvoteUp> Upvotes { get; set; } = new List<UpvoteUp>();
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();

        // Constructores
        public Post() { }

        public Post(int idPost, int idPerfil, DateTime fecha, string texto, int likes = 0, List<int> likesUsuarios = null)
        {
            IdPost = idPost;
            IdPerfil = idPerfil;
            Fecha = fecha;
            Texto = texto;   // Inicializar el texto
            Likes = likes;   // Inicializar el contador de likes
            LikesUsuarios = likesUsuarios ?? new List<int>(); // Inicializar la lista de usuarios que dieron like
        }

        // Métodos para gestionar relaciones
        public void AgregarImagen(PostImagen imagen)
        {
            if (imagen == null)
                throw new ArgumentNullException(nameof(imagen));
            PostImagens.Add(imagen);
        }

        public void EliminarImagen(PostImagen imagen)
        {
            if (imagen == null)
                throw new ArgumentNullException(nameof(imagen));
            PostImagens.Remove(imagen);
        }

        public void AgregarLink(PostLink link)
        {
            if (link == null)
                throw new ArgumentNullException(nameof(link));
            PostLinks.Add(link);
        }

        public void EliminarLink(PostLink link)
        {
            if (link == null)
                throw new ArgumentNullException(nameof(link));
            PostLinks.Remove(link);
        }

        public void AgregarUpvote(UpvoteUp upvote)
        {
            if (upvote == null)
                throw new ArgumentNullException(nameof(upvote));

            if (Upvotes.Any(u => u.IdPerfil == upvote.IdPerfil && u.IdPost == upvote.IdPost))
                throw new InvalidOperationException("El usuario ya ha dado un upvote a este post.");

            Upvotes.Add(upvote);
        }

        public void AgregarEvento(Evento evento)
        {
            if (evento == null)
                throw new ArgumentNullException(nameof(evento));
            Eventos.Add(evento);
        }

        public void EliminarEvento(Evento evento)
        {
            if (evento == null)
                throw new ArgumentNullException(nameof(evento));
            Eventos.Remove(evento);
        }

        public override string ToString()
        {
            return $"{IdPost} - {Fecha}";
        }
    }
}
