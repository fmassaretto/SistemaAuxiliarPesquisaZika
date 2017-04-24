using System.ComponentModel.DataAnnotations;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MinLength(3, ErrorMessage = "Campo nome tem que ter no minimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Campo nome tem que ter menos de 100 caractres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o e-mail")]
        [MinLength(3, ErrorMessage = "Campo e-mail tem que ter no minimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Campo e-mail tem que ter menos de 100 caractres")]
        [EmailAddress(ErrorMessage = "Campo e-mail invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MinLength(6, ErrorMessage = "Campo nome tem que ter no minimo 6 caracteres")]
        [MaxLength(100, ErrorMessage = "Campo nome tem que ter menos de 100 caractres")]
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }
    }
}