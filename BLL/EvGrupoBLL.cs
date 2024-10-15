using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class EvGrupoBLL
    {
        private readonly EvGrupoDAL evGrupoDAL;

        public EvGrupoBLL()
        {
            evGrupoDAL = new EvGrupoDAL();
        }

        public void InsertarEvGrupo(EvGrupo evGrupo)
        {
            evGrupoDAL.InsertarEvGrupo(evGrupo);
        }

        public void EliminarEvGrupo(int idGrupo, int idEvento)
        {
            evGrupoDAL.EliminarEvGrupo(idGrupo, idEvento);
        }

        public List<EvGrupo> ObtenerEvGrupos()
        {
            return evGrupoDAL.ObtenerEvGrupos();
        }
    }
}
