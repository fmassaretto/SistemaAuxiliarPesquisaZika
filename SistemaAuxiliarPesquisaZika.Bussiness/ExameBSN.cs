using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;
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

        //TODO: Ideal seria fazer um IEnumerable pois o paciente pode ter mais de um exame,
        // mas por motivo de facilidade só estou passando uma ViewModel (PacienteExameViewModel)
        //Atensão lembrar de mudar o @model da view
        public PacienteExameViewModel GetExameByIdPaciente(int? idPaciente)
        {
            var resultExame = (from p in _db.Paciente
                               join ep in _db.ExamesPaciente on p.Id equals ep.IdPaciente
                               where p.Id == idPaciente
                               select new PacienteExameViewModel{
                                   Paciente = p,
                                   ExamesPaciente = ep
                               }).FirstOrDefault();
            return resultExame;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
