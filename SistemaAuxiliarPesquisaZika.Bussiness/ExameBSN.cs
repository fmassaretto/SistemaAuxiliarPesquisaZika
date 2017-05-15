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
        private readonly AuxSystemResearchContext _db = new AuxSystemResearchContext();
        //private PacienteExameViewModel _pacientExameViewModel;
        public IEnumerable<PacienteExameViewModel> ConsultaPacientesComExame()
        {
            var resultQuery = (from p in _db.Paciente
                               join e in _db.ExamesPaciente on p.Id equals e.IdPaciente into allColumns
                               from selectAll in allColumns
                               select new PacienteExameViewModel()
                               {
                                   Paciente = p,
                                   ExamesPaciente = selectAll
                               }).ToList();
            return resultQuery;
        }

        //TODO: Ideal seria fazer um IEnumerable pois o paciente pode ter mais de um exame,
        // mas por motivo de facilidade só estou passando uma ViewModel (PacienteExameViewModel)
        //Atenção lembrar de mudar o @model da view
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

        public IEnumerable<RNExameViewModel> ConsultaRnComExame()
        {
            var resultQuery = (from rn in _db.RecemNascido
                               join e in _db.ExamesRecemNascido on rn.Id equals e.IdRecemNascido into allColumns
                               from selectAll in allColumns
                               select new RNExameViewModel()
                               {
                                   RecemNascido = rn,
                                   ExamesRecemNascido = selectAll
                               }).ToList();
            return resultQuery;
        }

        //TODO: Ideal seria fazer um IEnumerable pois o recém-nascido pode ter mais de um exame,
        // mas por motivo de facilidade só estou passando uma ViewModel (RNExameViewModel)
        //Atenção lembrar de mudar o @model da view
        public RNExameViewModel GetExameByIdRn(int? idRecemNascido)
        {
            var resultExame = (from rn in _db.RecemNascido
                               join e in _db.ExamesRecemNascido on rn.Id equals e.IdRecemNascido
                               where rn.Id == idRecemNascido
                               select new RNExameViewModel
                               {
                                   RecemNascido = rn,
                                   ExamesRecemNascido = e
                               }).FirstOrDefault();
            return resultExame;
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
