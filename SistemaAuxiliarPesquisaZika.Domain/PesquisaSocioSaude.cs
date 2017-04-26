using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("PesquisaSocioSaude")]
    public class PesquisaSocioSaude
    {
        public int Id { get; set; }
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
