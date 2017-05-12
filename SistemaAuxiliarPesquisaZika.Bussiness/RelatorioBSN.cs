using SistemaAuxiliarPesquisaZika.Bussiness.Abstract;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows.Forms;
using FileHelpers;
using static System.DateTime;

namespace SistemaAuxiliarPesquisaZika.Bussiness
{
    public class RelatorioBSN : RepositoryBSN<RelatorioPaciente>, IDisposable
    {
        private AuxSystemResearchContext _db = new AuxSystemResearchContext();

        public IEnumerable<RelatorioPaciente> SelectAllPaciente()
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

        public void GerarRelatorio(string nomeRelatorio)
        {
            //var engine = new FileHelperAsyncEngine<RelatorioPaciente>();
            DateTime date = DateTime.Now;
            var today = date.ToString("dd-MM-yyyy");
            //string path = Path.Combine(Application.StartupPath, "Relatorios", nomeRelatorio);
            string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;

            if (!Directory.Exists(rootPath))
            {
                if (rootPath != null) Directory.CreateDirectory(rootPath);
            }

            string fullPath = Path.Combine(@"E:\", nomeRelatorio + today + ".csv");
            if (rootPath != null)
            {

                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath);
                }
            }

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(fullPath, false);               
            }
            catch(Exception)
            {
                sw.Close();
            }

            //engine.BeginWriteFile("");

            var sap = SelectAllPaciente();

            foreach (var result in sap)
            {
                var resPaciente = result.Paciente;
                var resPesquisa = result.PesquisaSocioSaude;
                var resExame = result.ExamesPaciente;
                sw.Write(resPaciente.NumeroCaso);
                sw.Write(resPaciente.NomeCompleto);
                sw.Write(resPesquisa.VivePaiRN);
                sw.Write(resPesquisa.TrabalhoRemunerado);
                sw.Write(resExame.ResultadoHB);
                sw.Write(resExame.ResultadoHT);
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
