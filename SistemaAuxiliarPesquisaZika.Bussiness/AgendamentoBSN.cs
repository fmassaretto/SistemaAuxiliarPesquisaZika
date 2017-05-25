using System.Collections.Generic;
using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Domain;
using System.Linq;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.DTO;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class AgendamentoBSN : RepositoryBSN<AgendamentoExame>
    {
        private readonly AuxSystemResearchContext _db = new AuxSystemResearchContext();

        public AgendamentoViewModel GetAgendamento(int? idAgendamento)
        {
            var retorno = (from ae in _db.AgendamentoExame
                join p in _db.Paciente on ae.IdPaciente equals p.Id
                join u in _db.Usuarios on ae.IdUsuario equals u.Id
                where ae.Id == idAgendamento
                select new AgendamentoViewModel()
                {
                    Paciente = p,
                    Usuario = u,
                    AgendamnetoExame = ae
                }).FirstOrDefault();
            return retorno;
        }
    }
}
