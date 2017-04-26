
using System.ComponentModel.DataAnnotations;

namespace SistemaAuxiliarPesquisaZika.Domain.DTO
{
    public class PacienteViewModel
    {
        [Key]
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public PesquisaSocioSaude PesquisaSocioSaude { get; set; }

    }
}