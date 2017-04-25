using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table(nameof(RecemNascido))]
    public class RecemNascido
    {
        public int Id { get; set; }

        [DisplayName("Nome Recem-Nascido")]
        public string NomeCompleto { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }
        public int IdPaciente { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
