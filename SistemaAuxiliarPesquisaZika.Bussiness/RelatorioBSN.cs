using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class RelatorioBSN : RepositoryBSN<RelatorioPaciente>, IDisposable
    {
        private AuxSystemResearchContext _db = new AuxSystemResearchContext();

        public IEnumerable<RelatorioPaciente> GerarRelatorioTudo()
        {
            var result = from p in _db.Paciente
                         join ps in _db.PesquisaSocioSaude on p.Id equals ps.IdPaciente
                         join ep in _db.ExamesPaciente on p.Id equals ep.IdPaciente
                         select new RelatorioPaciente()
                         {
                             Paciente = p,
                             PesquisaSocioSaude = ps,
                             ExamesPaciente = ep
                         };
            return result;
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
