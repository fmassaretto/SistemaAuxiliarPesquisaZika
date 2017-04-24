﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table(nameof(Usuario))]
    public class Usuario
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
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [MinLength(6, ErrorMessage = "Minimo {0} caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }

        [ForeignKey("IdPerfil")]
        public virtual Perfil perfil { get; set; }

        /// <summary>
        /// Retorna a senha criptografada.
        /// OBS: a propriedade SENHA deve ter sido informada.
        /// </summary>
        //public string HashSenha
        //{
        //    get
        //    {
        //        return Senha.GerarHash();
        //    }
        //}
    }
}
