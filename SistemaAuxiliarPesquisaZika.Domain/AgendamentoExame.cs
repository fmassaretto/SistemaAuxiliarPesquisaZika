using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("AgendamentoExame")]
    public class AgendamentoExame
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        [DisplayName("Data do Exame")]
        public DateTime DataMarcadaExame { get; set; }

        private DateTime _dateToday;

        public DateTime DateToday => _dateToday.Date;

        [DisplayName("Médico Responsável pelo Exame")]
        public string MedicoExame { get; set; }

        [DisplayName("Nome do Exame")]
        public string NomeExame { get; set; }

        [DisplayName("Local do Exame")]
        public string LocalExame { get; set; }
        public Paciente Paciente { get; set; }
        public Usuario Usuario { get; set; }
    }
}
