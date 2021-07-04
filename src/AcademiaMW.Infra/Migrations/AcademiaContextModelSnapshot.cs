﻿// <auto-generated />
using System;
using AcademiaMW.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademiaMW.Infra.Migrations
{
    [DbContext(typeof(AcademiaContext))]
    partial class AcademiaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AcademiaMW.Business.Models.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ContratoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Contrato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataAquisicao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PlanoDescontoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PlanoDescontoId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Plano", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDesativacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.PlanoDesconto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Percentual")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("PlanoValorId")
                        .HasColumnType("char(36)");

                    b.Property<int>("QuantidadeMeses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanoValorId");

                    b.ToTable("PlanoDescontos");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.PlanoValor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataEncerramento")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PlanoId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("PlanoId");

                    b.ToTable("PlanoValor");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.UsuarioConfirmacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(6)");

                    b.Property<DateTime>("DateExpiracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateInicial")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioConfirmacao");
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Cliente", b =>
                {
                    b.HasOne("AcademiaMW.Business.Models.Contrato", "Contrato")
                        .WithMany()
                        .HasForeignKey("ContratoId")
                        .IsRequired();

                    b.HasOne("AcademiaMW.Business.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.OwnsOne("AcademiaMW.Business.Models.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Bairro")
                                .HasColumnType("varchar(250)");

                            b1.Property<string>("Cep")
                                .HasColumnType("varchar(8)");

                            b1.Property<string>("Cidade")
                                .HasColumnType("varchar(350)");

                            b1.Property<string>("Complemento")
                                .HasColumnType("varchar(200)");

                            b1.Property<string>("Estado")
                                .HasColumnType("varchar(2)");

                            b1.Property<string>("Logradouro")
                                .HasColumnType("varchar(350)");

                            b1.Property<string>("Numero")
                                .HasColumnType("varchar(15)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.OwnsOne("AcademiaMW.Core.ValueTypes.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Numero")
                                .HasColumnType("varchar(11)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.OwnsOne("AcademiaMW.Core.ValueTypes.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Endereco")
                                .HasColumnType("varchar(1000)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Contrato", b =>
                {
                    b.HasOne("AcademiaMW.Business.Models.PlanoDesconto", "PlanoDesconto")
                        .WithMany("Contratos")
                        .HasForeignKey("PlanoDescontoId")
                        .IsRequired();
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Funcionario", b =>
                {
                    b.HasOne("AcademiaMW.Business.Models.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .IsRequired();

                    b.HasOne("AcademiaMW.Business.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.OwnsOne("AcademiaMW.Core.ValueTypes.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("FuncionarioId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Numero")
                                .HasColumnType("varchar(11)");

                            b1.HasKey("FuncionarioId");

                            b1.ToTable("Funcionarios");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioId");
                        });

                    b.OwnsOne("AcademiaMW.Core.ValueTypes.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("FuncionarioId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Endereco")
                                .HasColumnType("varchar(300)");

                            b1.HasKey("FuncionarioId");

                            b1.ToTable("Funcionarios");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioId");
                        });
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.Permissao", b =>
                {
                    b.HasOne("AcademiaMW.Business.Models.Usuario", "Usuario")
                        .WithMany("Permissoes")
                        .HasForeignKey("UsuarioId")
                        .IsRequired();
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.PlanoDesconto", b =>
                {
                    b.HasOne("AcademiaMW.Business.Models.PlanoValor", "PlanoValor")
                        .WithMany("PlanoDescontos")
                        .HasForeignKey("PlanoValorId")
                        .IsRequired();
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.PlanoValor", b =>
                {
                    b.HasOne("AcademiaMW.Business.Models.Plano", "Plano")
                        .WithMany("PlanoValores")
                        .HasForeignKey("PlanoId")
                        .IsRequired();
                });

            modelBuilder.Entity("AcademiaMW.Business.Models.UsuarioConfirmacao", b =>
                {
                    b.HasOne("AcademiaMW.Business.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
