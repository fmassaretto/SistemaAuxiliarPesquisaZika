using SistemaAuxiliarPesquisaZika.Bussiness;
using System.Web.Mvc;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class RelatorioController : Controller
    {
        private RelatorioBSN _relatorioRepository = new RelatorioBSN();
        public ActionResult RelatorioAllDataPaciente()
        {
            var relatorio = _relatorioRepository.SelectAllPaciente();
            return View(relatorio);
        }

        public void GerarRelatorio()
        {
            _relatorioRepository.GerarRelatorio("Paciente");
        }
    }
}
