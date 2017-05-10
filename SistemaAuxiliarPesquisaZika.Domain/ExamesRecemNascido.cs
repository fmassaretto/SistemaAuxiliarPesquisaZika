using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("ExameRecemNascido")]
    public class ExamesRecemNascido
    {
        public int Id { get; set; }

        private DateTime _dataExameZika;
        [DisplayName("Data de Nascimento")]
        public DateTime DataExameZika
        {
            get { return _dataExameZika.Date; }
            set { _dataExameZika = value.Date; }
        }
        public string MaterialUtilizadoZika { get; set; }
        public string ResultadoZika { get; set; }

        private DateTime _dataExameChikunguia;
        [DisplayName("Data de Nascimento")]
        public DateTime DataExameChikunguia
        {
            get { return _dataExameChikunguia.Date; }
            set { _dataExameChikunguia = value.Date; }
        }
        public string MaterialUtilizadoChikunguia { get; set; }
        public string ResultadoChikunguia { get; set; }

        private DateTime _dataExameFebreAmarela;
        [DisplayName("Data de Nascimento")]
        public DateTime DataExameFebreAmarela
        {
            get { return _dataExameFebreAmarela.Date; }
            set { _dataExameFebreAmarela = value.Date; }
        }
        public string MaterialUtilizadoFebreAmarela { get; set; }
        public string ResultadoFebreAmarela { get; set; }

        private DateTime _dataExameToxoplasmose;
        [DisplayName("Data de Nascimento")]
        public DateTime DataExameToxoplasmose
        {
            get { return _dataExameToxoplasmose.Date; }
            set { _dataExameToxoplasmose = value.Date; }
        }
        public string MaterialUtilizadoToxoplasmose { get; set; }
        public string ResultadoToxoplasmose { get; set; }
        public RecemNascido RecemNascido { get; set; }
    }
}
