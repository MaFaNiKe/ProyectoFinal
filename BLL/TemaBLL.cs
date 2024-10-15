using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class TemaBLL
    {
        private readonly TemaDAL temaDAL;

        public TemaBLL()
        {
            temaDAL = new TemaDAL(); 
        }

        public List<Tema> ObtenerTemas()
        {
            return temaDAL.ObtenerTemas();
        }

        public void InsertarTema(Tema tema)
        {
            temaDAL.InsertarTema(tema);
        }

        public void ActualizarTema(Tema tema)
        {
            temaDAL.ActualizarTema(tema);
        }

        public void EliminarTema(int idTema)
        {
            temaDAL.EliminarTema(idTema);
        }
    }
}
