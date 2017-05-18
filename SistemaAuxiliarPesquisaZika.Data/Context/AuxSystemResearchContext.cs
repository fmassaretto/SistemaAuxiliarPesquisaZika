using System.Data.Entity;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Data.EntityConfig;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;
using SistemaAuxiliarPesquisaZika.Domain.DTO;

namespace SistemaAuxiliarPesquisaZika.Data.Context
{
    public class AuxSystemResearchContext : DbContext
    {
        public AuxSystemResearchContext() : base("Default")
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<UsuarioPerfilViewModel> UsuarioPerfilViewModel { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<RecemNascido> RecemNascido { get; set; }
        public DbSet<SocioeconomicoPaciente> PesquisaSocioSaude { get; set; }
        public DbSet<ExamesPaciente> ExamesPaciente { get; set; }
        public DbSet<AgendamentoExame> AgendamentoExame { get; set; }
        public DbSet<PacienteViewModel> PacienteViewModels { get; set; }
        public DbSet<ExamesRecemNascido> ExamesRecemNascido { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
            .Where(x =>
                x.PropertyType.FullName.Equals("System.String") &&
                !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(q => q.TypeName != null && q.TypeName.Equals("varchar", StringComparison.InvariantCultureIgnoreCase)))
            .Configure(c =>
                c.HasColumnType("varchar").HasMaxLength(200));

            modelBuilder.Configurations.Add(new RecemNascidoConfiguration());
            modelBuilder.Configurations.Add(new PacienteConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new SocioeconomicoPacienteConfiguration());
            modelBuilder.Configurations.Add(new ExamePacienteConfiguration());
            modelBuilder.Configurations.Add(new ExameRecemNascidoConfiguration());
            modelBuilder.Configurations.Add(new AgendamentoExameConfiguration());
        }

    }
}
