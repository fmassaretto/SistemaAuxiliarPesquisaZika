﻿using SistemaAuxiliarPesquisaZika.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SistemaAuxiliarPesquisaZika.Data.EntityConfig
{
    public class PacienteConfiguration : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NomeCompleto).IsRequired();
        }
    }
}
