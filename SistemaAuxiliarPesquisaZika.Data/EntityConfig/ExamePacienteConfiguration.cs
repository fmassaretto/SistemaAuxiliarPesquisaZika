using SistemaAuxiliarPesquisaZika.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class ExamePacienteConfiguration : EntityTypeConfiguration<ExamesPaciente>
    {
        public ExamePacienteConfiguration()
        {
            HasKey(x => x.Id);
            Property(y => y.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Paciente)
                .WithMany(x => x.ExamesPaciente)
                .HasForeignKey(x => x.IdPaciente);
            Property(x => x.DataExame).IsRequired();
        }
    }
}
