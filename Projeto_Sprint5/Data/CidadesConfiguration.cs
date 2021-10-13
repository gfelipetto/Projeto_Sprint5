using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Sprint5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sprint5.Data
{
    public class CidadesConfiguration : IEntityTypeConfiguration<Cidades>
    {
        public void Configure(EntityTypeBuilder<Cidades> builder)
        {
            builder.ToTable("Cidades");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(c => c.Estado)
                .HasColumnName("Estado")
                .IsRequired();
        }
    }
}
