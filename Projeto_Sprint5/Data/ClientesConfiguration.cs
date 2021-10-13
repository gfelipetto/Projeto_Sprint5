using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Sprint5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sprint5.Data
{
    public class ClientesConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("Clientes");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            builder.Property(c => c.Cep)
                .HasColumnName("Cep")
                .IsRequired();

            builder.Property(c => c.Logradouro)
                .HasColumnName("Logradouro")
                .IsRequired();

            builder.Property(c => c.Bairro)
                .HasColumnName("Bairro")
                .IsRequired();

            builder.Property(c => c.CidadeId)
                .HasColumnName("CidadeId")
                .IsRequired();

            builder.HasOne(c => c.ResidenteDe)
                .WithMany(ci => ci.ClientesQueHabitam)
                .HasForeignKey("CidadeId");
        }
    }
}
