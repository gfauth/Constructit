﻿using ControleCondominal.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleCondominal.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Morador> Moradors { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Condominio>().Property(c => c.Id).IsRequired(true);
        }
    }
}
