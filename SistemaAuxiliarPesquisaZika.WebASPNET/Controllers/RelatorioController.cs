using SistemaAuxiliarPesquisaZika.Bussiness;
using System.Web.Mvc;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class RelatorioController : Controller
    {
        private RelatorioBSN _relatorioRepository = new RelatorioBSN();
        public ActionResult RelatorioAllDataPaciente()
        {
            var relatorio = _relatorioRepository.SelectAllInfoPaciente();
            return View(relatorio);
        }

        public void GerarRelatorio()
        {
            string nomeRelatorio = "RelatorioPaciente";

            Response.ClearContent();
            Response.AddHeader("content-disposition", $"attachment;filename={nomeRelatorio}.csv");
            Response.ContentType = "application/octet-stream";

            var sap = _relatorioRepository.SelectAllInfoPaciente();

            foreach (var result in sap)
            {
                var resPaciente = result.Paciente;
                var resPesquisa = result.PesquisaSocioSaude;
                var resExame = result.ExamesPaciente;
                var csvPaciente = $"{resPaciente.NumeroCaso},{resPaciente.NomeCompleto}";
                var csvPesquisa = $"{resPesquisa.VivePaiRN},{resPesquisa.TrabalhoRemunerado}";
                var csvExame = $"{resExame.ResultadoHB},{resExame.ResultadoHT}";
                
                Response.Write(string.Concat(csvPaciente, csvPesquisa, csvExame));
                Response.Write('\n');
            }
            
            Response.End();
        }
    }
}
