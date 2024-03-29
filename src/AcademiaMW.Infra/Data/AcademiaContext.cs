﻿using AcademiaMW.Business.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcademiaMW.Infra.Data
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options) 
            : base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<PlanoDesconto> PlanoDescontos { get; set; }
        public DbSet<PlanoValor> PlanoValor { get; set; }
        public DbSet<UsuarioConfirmacao> UsuarioConfirmacao { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<PerfilPermissao> PerfilPermissoes { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfis { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<TreinoItem> TreinoItens { get; set; }
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
