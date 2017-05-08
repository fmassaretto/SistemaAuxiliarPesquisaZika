using SistemaAuxiliarPesquisaZika.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("ExamePaciente")]
    public class ExamesPaciente
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }

        private DateTime dataExame;
        [DisplayName("Data do Exame")]
        public DateTime DataExame
        {
            get { return dataExame.Date; }
            set { dataExame = value.Date; }
        }
        public float ResultadoHB { get; set; }
        public float ResultadoHT { get; set; }
        public string ResultadoLeucograma { get; set; }
        public int ResultadoPlaquetas { get; set; }
        public string ResultadoSaliva { get; set; }
        public string ResultadoUrina { get; set; }
        public string ResultadoSangue { get; set; }
        public string ResultadoToxoplasmose { get; set; }

        public string selecionadoResultadoLues;
        public ICollection<ReagenteNaoReagente> ResultadoLues
        {
            get
            {
                return Constants.ListaReagenteNaoReagente;
            }
            set
            {
                selecionadoResultadoLues = value.ToString();
            }
        }

        public virtual Paciente Paciente { get; set; }
    }
}
