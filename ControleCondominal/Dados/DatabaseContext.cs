using Dados.Models;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Morador> Moradors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Condominio>().Property(c => c.Id).IsRequired(true);
        }
    }
}
