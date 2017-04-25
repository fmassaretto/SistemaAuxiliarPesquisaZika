using SistemaAuxiliarPesquisaZika.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class RecemNascidoConfiguration : EntityTypeConfiguration<RecemNascido>
    {
        public RecemNascidoConfiguration()
        {
            HasKey(y => y.Id);
            Property(y => y.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(y => y.Paciente)
                .WithMany(y => y.RecemNascido)
                .HasForeignKey(y => y.IdPaciente);

            Property(y => y.NomeCompleto)
                .IsRequired();

            Property(y => y.IdPaciente)
                .IsRequired();
        }
    }
}
