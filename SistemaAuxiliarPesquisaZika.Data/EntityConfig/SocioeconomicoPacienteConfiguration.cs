using SistemaAuxiliarPesquisaZika.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class SocioeconomicoPacienteConfiguration : EntityTypeConfiguration<SocioeconomicoPaciente>
    {
        public SocioeconomicoPacienteConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Paciente).WithMany(y => y.PesquisaSocioSaude).HasForeignKey(z => z.IdPaciente);

            //HasRequired(x => x.Paciente).WithRequiredDependent(y => y.PesquisaSocioSaude);
            //HasRequired(x => x.Paciente).WithOptional(y => y.PesquisaSocioSaude);

            Property(x => x.IdPaciente).IsRequired();
        }
    }
}
