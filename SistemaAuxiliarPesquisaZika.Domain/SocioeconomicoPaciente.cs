using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("SocioeconomicoPaciente")]
    public class SocioeconomicoPaciente
    {
        public int Id { get; set; }

        [DisplayName("Faz trabalho remunerado?")]
        public bool TrabalhoRemunerado { get; set; }
        [DisplayName("Vive com o pai do recém-nascido?")]
        public bool VivePaiRN { get; set; }
        [DisplayName("Fuma?")]
        public bool Fuma { get; set; }
        [DisplayName("Usa alguma droga?")]
        public bool UsoDrogas { get; set; }
        [DisplayName("Numero de cigarros por dia:")]
        public int NumeroCigarrosDia { get; set; }
        [DisplayName("Tem diabetes?")]
        public bool TemDiabetes { get; set; }
        [DisplayName("Tem hipertensão?")]
        public bool TemHipertensao { get; set; }
        [DisplayName("Está satisfeita com a gravidez?")]
        public bool SatisfacaoGravidez { get; set; }
        [DisplayName("Tentou interromper a gravidez?")]
        public bool TentativaInterromperGravidez { get; set; }
        [DisplayName("Teve aborto anteriores?")]
        public bool AbortosAnteriores { get; set; }
        [DisplayName("Quanto(s) aborto(s)?")]
        public int QuantosAborto { get; set; }
        [DisplayName("Motivo do aborto:")]
        public string MotivoAborto { get; set; }
        public int IdPaciente { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
