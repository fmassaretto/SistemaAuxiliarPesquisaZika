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
            context.Perfil.AddOrUpdate(
                p => p.Id,
                new Perfil() { Id = 1, Nome = "Administrador" },
                new Perfil() { Id = 2, Nome = "Pesquisador" },
                new Perfil() { Id = 3, Nome = "Médico" },
                new Perfil() { Id = 4, Nome = "Preenchedor" }
                );

            //context.Usuarios.AddOrUpdate(
            //    u => u.Id,
            //    new Usuario() { Id = 1, Nome = "Admin", Email = "admin@g.com", Senha = "123123", ConfirmaSenha = "123123", Ativo = true, IdPerfil = 1 },
            //    new Usuario() { Id = 2, Nome = "João (Pesquisador)", Email = "joao@g.com", Senha = "123123", ConfirmaSenha = "123123", Ativo = true, IdPerfil = 2 },
            //    new Usuario() { Id = 3, Nome = "Pedro (Médico)", Email = "pedro@g.com", Senha = "123123", ConfirmaSenha = "123123", Ativo = true, IdPerfil = 3 },
            //    new Usuario() { Id = 4, Nome = "Ana (Preenchedor)", Email = "ana@g.com", Senha = "123123", ConfirmaSenha = "123123", Ativo = true, IdPerfil = 4 }
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
