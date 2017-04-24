using SistemaAuxiliarPesquisaZika.Domain;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels
{
    public class UsuariosViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MinLength(3, ErrorMessage = "Minimo {0} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o e-mail")]
        [MinLength(3, ErrorMessage = "Minimo {0} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Campo e-mail invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [MinLength(6, ErrorMessage = "Minimo {0} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Senha), ErrorMessage = "A senha e confirmação não coincidem")]
        public int ConfirmaSenha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }

        [DisplayName(nameof(Perfil))]
        public IEnumerable<SelectListItem> ListaPerfil { get; set; }
    }
}