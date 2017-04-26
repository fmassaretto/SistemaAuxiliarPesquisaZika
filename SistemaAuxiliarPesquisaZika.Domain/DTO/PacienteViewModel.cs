
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain.DTO
{
    [Table("InformacoesPaciente")]
    public class PacienteViewModel
    {
        [Key]
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
        public bool TrabalhoRemunerado { get; set; }
        public bool VivePaiRN { get; set; }
        public bool Fuma { get; set; }
        public bool UsoDrogas { get; set; }
        public int NumeroCigarrosDia { get; set; }
        public bool TemDiabetes { get; set; }
        public bool TemHipertensao { get; set; }
        public bool SatisfacaoGravidez { get; set; }
        public bool TentativaInterromperGravidez { get; set; }
        public bool AbortosAnteriores { get; set; }
        public int QuantosAborto { get; set; }
        public string MotivoAborto { get; set; }

        public virtual Paciente Paciente { get; set; }

    }
}