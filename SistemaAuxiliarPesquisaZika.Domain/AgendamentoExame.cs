using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("AgendamentoExame")]
    public class AgendamentoExame
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataMarcadaExame { get; set; }
        public DateTime DataHoje { get; set; }
        public string NomeExame { get; set; }
        public string LocalExame { get; set; }
    }
}
