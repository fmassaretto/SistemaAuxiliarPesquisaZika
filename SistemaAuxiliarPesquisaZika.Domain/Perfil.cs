using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAuxiliarPesquisaZika.Domain
{
    [Table(nameof(Perfil))]
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
