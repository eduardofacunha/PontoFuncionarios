using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PontoFuncionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoFuncionarios.Context
{
    public class BancoContext : DbContext
    {
        public static string ConnectionString { get; set; } = "Server=localhost;Port=5432;Database=test;User Id=postgres;Password=postgres;";
        public DbSet<Ponto> Ponto { get; set; }
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public BancoContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ponto>(entity =>
            {
                entity.ToTable("ponto");
                entity.HasKey(x => x.IdPonto);
            });
        }
    }
}
