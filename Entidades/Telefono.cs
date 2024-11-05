using System;

namespace Entidades
{
    public class Telefono
    {
        public int IdPerfil { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; }

        // Constructores
        public Telefono() { }

        public Telefono(int idPerfil, string numero, string tipo)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("El número no puede ser nulo o vacío.", nameof(numero));
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("El tipo no puede ser nulo o vacío.", nameof(tipo));

            IdPerfil = idPerfil;
            Numero = numero;
            Tipo = tipo;
        }

        // Métodos
        public string ObtenerInformacionBasica()
        {
            return $"ID Perfil: {IdPerfil}, Número: {Numero}, Tipo: {Tipo}";
        }
    }
}
