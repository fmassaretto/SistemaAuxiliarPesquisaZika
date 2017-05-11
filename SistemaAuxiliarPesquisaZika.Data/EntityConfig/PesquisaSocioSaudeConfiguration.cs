using SistemaAuxiliarPesquisaZika.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class PesquisaSocioSaudeConfiguration : EntityTypeConfiguration<PesquisaSocioSaude>
    {
        public PesquisaSocioSaudeConfiguration()
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
