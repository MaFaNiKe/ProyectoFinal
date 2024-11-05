using System;

namespace Entidades
{
    public class PostLink
    {
        public int IdLink { get; set; }
        public int IdPost { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSubida { get; set; }

        // Relaciones
        public Post Post { get; set; }

        // Constructores
        public PostLink()
        {
            FechaSubida = DateTime.Now; 
        }

        public PostLink(int idLink, int idPost, string url, string descripcion, DateTime fechaSubida)
        {
            IdLink = idLink;
            IdPost = idPost;
            Url = url;
            Descripcion = descripcion;
            FechaSubida = fechaSubida;
        }

        // Métodos
        public void ActualizarUrl(string nuevaUrl)
        {
            if (string.IsNullOrWhiteSpace(nuevaUrl))
                throw new ArgumentException("La URL no puede estar vacía", nameof(nuevaUrl));

            Url = nuevaUrl;
        }

        public void ActualizarDescripcion(string nuevaDescripcion)
        {
            if (string.IsNullOrWhiteSpace(nuevaDescripcion))
                throw new ArgumentException("La descripción no puede estar vacía", nameof(nuevaDescripcion));

            Descripcion = nuevaDescripcion;
        }

        public override string ToString()
        {
            return $"Link {IdLink}: {Url} - {Descripcion}";
        }
    }
}
