using SistemaAuxiliarPesquisaZika.Domain.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MinLength(3, ErrorMessage = "Minimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o e-mail")]
        [MinLength(3, ErrorMessage = "Minimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "Campo e-mail invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [MinLength(6, ErrorMessage = "Minimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirmar Senha")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e confirmação não coincidem")]
        public string ConfirmaSenha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }
        [NotMapped]
        public string NomePerfil { get; set; }
        public virtual Perfil Perfil { get; set; }
        public ICollection<AgendamentoExame> AgendamentoExame { get; set; }

        public Usuario(int id, string nome, string email, bool ativo, Perfil perfil)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Ativo = ativo;
            Perfil = perfil;
            Perfil = new Perfil();
        }

        public Usuario(){ }

        /// <summary>
        /// Retorna a senha criptografada.
        /// OBS: a propriedade SENHA deve ter sido informada.
        /// </summary>
        public string HashSenha
        {
            get
            {
                return Senha.GerarHash();
            }
        }
    }
}
