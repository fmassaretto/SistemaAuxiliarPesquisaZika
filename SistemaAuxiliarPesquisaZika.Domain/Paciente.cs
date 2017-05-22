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
        [DisplayName("Número do Caso:")]
        public int NumeroCaso { get; set; }

        [DisplayName("Nome da Paciente:")]
        public string NomeCompleto { get; set; }
        [DisplayName("CPF:")]
        public string CPF { get; set; }
        [DisplayName("RG:")]
        public string RG { get; set; }
        [DisplayName("Endereço:")]
        public string Endereco { get; set; }
        [DisplayName("Bairro:")]
        public string Bairro { get; set; }
        [DisplayName("Cidade:")]
        public string Cidade { get; set; }
        [DisplayName("UBS que Frequenta:")]
        public string UBSFrequenta { get; set; }
        [DisplayName("E-mail:")]
        public string Email { get; set; }
        public string Telefone { get; set; }
      
        private DateTime dataNascimento;
        [DisplayName("Data de Nascimento:")]
        public DateTime DataNascimento
        {
            get { return dataNascimento.Date; }
            set { dataNascimento = value.Date; }
        }

        public ICollection<RecemNascido> RecemNascido { get; set; }
        public ICollection<ExamesPaciente> ExamesPaciente { get; set; }
        public ICollection<SocioeconomicoPaciente> SocioeconomicoPaciente { get; set; }
        public ICollection<AgendamentoExame> AgendamentoExame { get; set; }
    }
}
