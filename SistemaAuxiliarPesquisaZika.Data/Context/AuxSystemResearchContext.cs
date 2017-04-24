using System.Data.Entity;
using SistemaAuxiliarPesquisaZika.Domain;

namespace SistemaAuxiliarPesquisaZika.Data.Context
{
    public class AuxSystemResearchContext : DbContext
    {
        public AuxSystemResearchContext() : base("Default")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
    }
}
