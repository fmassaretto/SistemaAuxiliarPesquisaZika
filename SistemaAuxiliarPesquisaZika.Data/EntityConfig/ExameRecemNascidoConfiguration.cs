using SistemaAuxiliarPesquisaZika.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class ExameRecemNascidoConfiguration : EntityTypeConfiguration<ExamesRecemNascido>
    {
        public ExameRecemNascidoConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //HasRequired(x => x.RecemNascido).WithOptional(y => y.ExamesRecemNascido);
        }
    }
}
