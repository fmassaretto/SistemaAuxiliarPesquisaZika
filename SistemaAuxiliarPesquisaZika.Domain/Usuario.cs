using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }

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
