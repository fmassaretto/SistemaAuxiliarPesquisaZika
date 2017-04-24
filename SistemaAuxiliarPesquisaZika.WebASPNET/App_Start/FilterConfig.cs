using System.Web;
using System.Web.Mvc;

namespace SistemaAuxiliarPesquisaZika.WebASPNET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
