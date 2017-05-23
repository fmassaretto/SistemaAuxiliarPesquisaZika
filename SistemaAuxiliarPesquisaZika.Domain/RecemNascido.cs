using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table(nameof(RecemNascido))]
    public class RecemNascido
    {
        public int Id { get; set; }

        [DisplayName("Nome Recém-Nascido:")]
        public string NomeCompleto { get; set; }

        private DateTime dataNascimento;
        [DisplayName("Data de Nascimento:")]
        public DateTime DataNascimento
        {
            get { return dataNascimento.Date; }
            set { dataNascimento = value.Date; }
        }
        public int IdPaciente { get; set; }
        public int IdExamesRN { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ExamesRecemNascido ExamesRecemNascido { get; set; }
    }
}
