using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class RelatorioBSN : RepositoryBSN<RelatorioPaciente>
    {
        private readonly AuxSystemResearchContext _db = new AuxSystemResearchContext();

        public IEnumerable<RelatorioPaciente> SelectAllInfoPaciente()
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

        public string CriarDiretorioEArquivo(string nomeRelatorio)
        {
            //var engine = new FileHelperAsyncEngine<RelatorioPaciente>();
            DateTime date = DateTime.Now;
            var today = date.ToString("dd-MM-yyyy");
            //string rootpath = Path.Combine(Application.StartupPath, "Relatorios", nomeRelatorio);
            string rootPath = Directory.GetCurrentDirectory().ToString();

            if (!Directory.Exists(rootPath))
            {
                if (rootPath != null) Directory.CreateDirectory(rootPath);
            }

            string fullPath = Path.Combine(@"N:\Publico\FMASSARETTO", nomeRelatorio + today + ".csv");
            if (rootPath != null)
            {

                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath);
                }
            }
            return fullPath;
        }
    }
}
