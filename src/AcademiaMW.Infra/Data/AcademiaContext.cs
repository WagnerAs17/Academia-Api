using AcademiaMW.Business.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcademiaMW.Infra.Data
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Endereco>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcademiaContext).Assembly);

            foreach (var relatioship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
                relatioship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
