using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class EventoBLL
    {
        private readonly EventoDAL eventoDAL;

        public EventoBLL()
        {
            eventoDAL = new EventoDAL(); 
        }

        public void InsertarEvento(Evento evento)
        {
            eventoDAL.InsertarEvento(evento);
        }

        public void EliminarEvento(int idEvento)
        {
            eventoDAL.EliminarEvento(idEvento);
        }

        public void ActualizarEvento(Evento evento)
        {
            eventoDAL.ActualizarEvento(evento);
        }

        public List<Evento> ObtenerEventos()
        {
            return eventoDAL.ObtenerEventos();
        }

        public Evento ObtenerEventoPorId(int idEvento)
        {
            return eventoDAL.ObtenerEventoPorId(idEvento);
        }
    }
}
