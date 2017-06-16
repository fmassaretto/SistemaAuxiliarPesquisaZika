using SistemaAuxiliarPesquisaZika.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("ExamePaciente")]
    public class ExamesPaciente
    {
        public int Id { get; set; }
        [DisplayName("Nome do Paciente")]
        public int IdPaciente { get; set; }

        private DateTime dataExame;
        [DisplayName("Data do Exame")]
        public DateTime DataExame
        {
            get { return dataExame.Date; }
            set { dataExame = value.Date; }
        }
        [DisplayName("Resultado do Exame HB")]
        public float ResultadoHB { get; set; }
        [DisplayName("Resultado do Exame HT")]
        public float ResultadoHT { get; set; }
        [DisplayName("Resultado do Exame de Leucograma")]
        public string ResultadoLeucograma { get; set; }
        [DisplayName("Resultado do Exame de Plaquetas")]
        public int ResultadoPlaquetas { get; set; }
        [DisplayName("Resultado do Exame de Saliva")]
        public string ResultadoSaliva { get; set; }
        [DisplayName("Resultado do Exame de Urina")]
        public string ResultadoUrina { get; set; }
        [DisplayName("Resultado do Exame de Sangue")]
        public string ResultadoSangue { get; set; }
        [DisplayName("Resultado do Exame de Toxoplasmose")]
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
