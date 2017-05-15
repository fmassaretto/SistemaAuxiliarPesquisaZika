using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SistemaAuxiliarPesquisaZika.Domain;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class AgendamentoExameConfiguration : EntityTypeConfiguration<AgendamentoExame>
    {
        public AgendamentoExameConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Paciente).WithMany(y => y.AgendamentoExame).HasForeignKey(z => z.IdPaciente);
            HasRequired(x => x.Usuario).WithMany(y => y.AgendamentoExame).HasForeignKey(z => z.IdUsuario);
        }
    }
}
