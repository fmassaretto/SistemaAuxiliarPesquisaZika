using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SistemaAuxiliarPesquisaZika.Data.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<AuxSystemResearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuxSystemResearchContext context)
        {
            //context.Perfil.AddOrUpdate(
            //    p => p.Nome,
            //    new Perfil { Nome = "Administrador" },
            //    new Perfil { Nome = "Pesquisador" },
            //    new Perfil { Nome = "Médico" },
            //    new Perfil { Nome = "Preenchedor" }
            //    );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
