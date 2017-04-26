using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        public int Id { get; set; }
        public int NumeroCaso { get; set; }

        [DisplayName("Nome Paciente")]
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UBSFrequenta { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public ICollection<RecemNascido> RecemNascido { get; set; }
        public PesquisaSocioSaude PesquisaSocioSaude { get; set; }
    }
}
