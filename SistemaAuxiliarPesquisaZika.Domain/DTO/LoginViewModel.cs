using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SistemaAuxiliarPesquisaZika.Domain.DTO
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Preencha o email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Manter conectado?")]
        public bool ManterConectado { get; set; }
    }
}
