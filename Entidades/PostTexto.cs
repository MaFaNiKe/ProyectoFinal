using System;
using System.Collections.Generic;

namespace Entidades
{
    public class PostTexto
    {
        public int IdTexto { get; set; }
        public int IdPost { get; set; }
        public string ContenidoTexto { get; set; }
        public DateTime FechaSubida { get; set; }
        public List<string> Comentarios { get; set; } = new List<string>();

        // Relaciones
        public Post Post { get; set; }

        // Constructor
        public PostTexto()
        {
            FechaSubida = DateTime.Now;
        }

        public PostTexto(int idTexto, int idPost, string contenidoTexto, DateTime fechaSubida)
        {
            IdTexto = idTexto;
            IdPost = idPost;
            ContenidoTexto = contenidoTexto;
            FechaSubida = fechaSubida;
        }

        // Métodos adicionales
        public void AgregarComentario(string comentario)
        {
            if (string.IsNullOrWhiteSpace(comentario))
                throw new ArgumentException("El comentario no puede estar vacío.");

            Comentarios.Add(comentario);
        }

        public override string ToString()
        {
            return $"Texto {IdTexto} en Post {IdPost}: {ContenidoTexto} (Fecha de subida: {FechaSubida.ToShortDateString()})";
        }
    }
}
