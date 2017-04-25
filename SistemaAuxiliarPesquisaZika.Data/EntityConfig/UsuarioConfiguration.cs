using SistemaAuxiliarPesquisaZika.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.Email).IsRequired();
            Property(x => x.Senha).IsRequired();
            Property(x => x.ConfirmaSenha).IsRequired();
        }
    }
}
