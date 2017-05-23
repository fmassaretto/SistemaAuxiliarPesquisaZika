using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table("ExameRecemNascido")]
    public class ExamesRecemNascido
    {
        public int Id { get; set; }

        public int IdRecemNascido { get; set; }

        private DateTime _dataExameZika;
        [DisplayName("Data Exame Zika:")]
        public DateTime DataExameZika
        {
            get { return _dataExameZika.Date; }
            set { _dataExameZika = value.Date; }
        }
        [DisplayName("Material Utilizado (Zika):")]
        public string MaterialUtilizadoZika { get; set; }
        [DisplayName("Resultado de Zika:")]
        public string ResultadoZika { get; set; }

        private DateTime _dataExameChikunguia;
        [DisplayName("Data Exame Chikungunya:")]
        public DateTime DataExameChikunguia
        {
            get { return _dataExameChikunguia.Date; }
            set { _dataExameChikunguia = value.Date; }
        }
        [DisplayName("Material Utilizado (Chikungunya):")]
        public string MaterialUtilizadoChikunguia { get; set; }
        [DisplayName("Resultado de Chikungunya:")]
        public string ResultadoChikunguia { get; set; }

        private DateTime _dataExameFebreAmarela;
        [DisplayName("Data Exame Febre Amarela:")]
        public DateTime DataExameFebreAmarela
        {
            get { return _dataExameFebreAmarela.Date; }
            set { _dataExameFebreAmarela = value.Date; }
        }
        [DisplayName("Material Utilizado (Febre Amarela):")]
        public string MaterialUtilizadoFebreAmarela { get; set; }
        [DisplayName("Resultado de Febre Amarela:")]
        public string ResultadoFebreAmarela { get; set; }

        private DateTime _dataExameToxoplasmose;
        [DisplayName("Data Exame Toxoplasmose:")]
        public DateTime DataExameToxoplasmose
        {
            get { return _dataExameToxoplasmose.Date; }
            set { _dataExameToxoplasmose = value.Date; }
        }
        [DisplayName("Material Utilizado (Toxoplasmose):")]
        public string MaterialUtilizadoToxoplasmose { get; set; }
        [DisplayName("Resultado de Toxoplasmose:")]
        public string ResultadoToxoplasmose { get; set; }
        public ICollection<RecemNascido> RecemNascido { get; set; }
    }
}
