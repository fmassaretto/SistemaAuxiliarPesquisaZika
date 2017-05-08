using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class ExameBSN : RepositoryBSN<PacienteExameViewModel>, IDisposable
    {
        private AuxSystemResearchContext _db = new AuxSystemResearchContext();
        private PacienteExameViewModel _pacientExameViewModel;
        public IEnumerable<PacienteExameViewModel> ConsultaPacientesComExame()
        {
            var resultQuery = (from p in _db.Paciente
                               join e in _db.ExamesPaciente on p.Id equals e.IdPaciente into AllColumns
                               from SelectAll in AllColumns
                               select new PacienteExameViewModel()
                               {
                                   Paciente = p,
                                   ExamesPaciente = SelectAll
                               }).ToList();
            return resultQuery;

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
