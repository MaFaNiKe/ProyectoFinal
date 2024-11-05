using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidades
{
    public class Post
    {
        public int IdPost { get; set; }
        public int IdPerfil { get; set; }
        public DateTime Fecha { get; set; }
        public string ContenidoTexto { get; set; }
        public string ContenidoImagen { get; set; }
        public string ContenidoLink { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; } 
        public ICollection<PostImagen> PostImagens { get; set; } = new List<PostImagen>();
        public ICollection<PostTexto> PostTextos { get; set; } = new List<PostTexto>();
        public ICollection<PostLink> PostLinks { get; set; } = new List<PostLink>();
        public ICollection<UpvoteUp> Upvotes { get; set; } = new List<UpvoteUp>();
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();

        // Constructores
        public Post() { }

        public Post(int idPost, int idPerfil, DateTime fecha, string contenidoTexto, string contenidoImagen, string contenidoLink)
        {
            IdPost = idPost;
            IdPerfil = idPerfil;
            Fecha = fecha;
            ContenidoTexto = contenidoTexto;
            ContenidoImagen = contenidoImagen;
            ContenidoLink = contenidoLink;
        }

        // Métodos
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

        public void AgregarTexto(PostTexto texto)
        {
            if (texto == null)
                throw new ArgumentNullException(nameof(texto));

            PostTextos.Add(texto);
        }

        public void EliminarTexto(PostTexto texto)
        {
            if (texto == null)
                throw new ArgumentNullException(nameof(texto));

            PostTextos.Remove(texto);
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

            // Verifica si el usuario ya ha dado un upvote a este post
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
            return $"{IdPost} - {ContenidoTexto}";
        }
    }
}
