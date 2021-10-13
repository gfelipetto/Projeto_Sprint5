using Microsoft.EntityFrameworkCore;
using Projeto_Sprint5.Models;

namespace Projeto_Sprint5.Data
{
    public class CidadeClienteContext : DbContext
    {
        public CidadeClienteContext(DbContextOptions<CidadeClienteContext> options) : base(options)
        {}
        public DbSet<Cidades> Cidades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadesConfiguration());
            modelBuilder.ApplyConfiguration(new ClientesConfiguration());
        }

    }
}
