﻿using System.Collections.Generic;
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
        [System.ComponentModel.DataAnnotations.Compare(nameof(Senha), ErrorMessage = "A senha e confirmação não coincidem")]
        public int ConfirmaSenha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }

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
