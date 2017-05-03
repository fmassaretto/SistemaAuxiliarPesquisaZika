using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels
{
    public class UsuariosViewModel : Usuario
    {
        [DisplayName(nameof(Perfil))]
        public IEnumerable<SelectListItem> ListaPerfilColection { get; set; }
        public SelectList PerfilSelecionado { get; set; }
        public UsuariosViewModel()
        {
            PerfilSelecionado = new SelectList(ListaPerfilColection);
        }
    }
}