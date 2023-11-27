using CadastroPessoa.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Persistence
{
    public class ClienteContext : DbContext
    {
        private readonly string _connection;
        public ClienteContext(string connection)
        {
            _connection = connection;
        }
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection);
                optionsBuilder.EnableDetailedErrors();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Indexes
            modelBuilder.Entity<Pessoa>()
                .HasIndex(x => new { x.CPF, x.Tipo }).IsUnique();

            modelBuilder.Entity<Pessoa>()
                .HasIndex(x => x.CNPJ).IsUnique();

            modelBuilder.Entity<Pessoa>()
                .HasIndex(x => x.Nome);

            modelBuilder.Entity<Pessoa>()
                .HasIndex(x => x.NomeSocial);

            modelBuilder.Entity<Pessoa>()
                .HasIndex(x => x.RazaoSocial);
            #endregion
        }
        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
