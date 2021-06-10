using AcademiaMW.Business.Models;
using AcademiaMW.Core.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(500)");

            builder.OwnsOne(x => x.Email, e =>
            {
                e.Property(x => x.Endereco)
                    .HasColumnType("varchar(1000)");
            });

            builder.OwnsOne(x => x.CPF, c =>
            {
                c.Property(x => x.Numero)
                .HasColumnType($"varchar({CPF.Max_Length})");
            });

            builder.OwnsOne(x => x.Endereco, end =>
            {
                end.Property(x => x.Numero)
                    .HasColumnType("varchar(15)");

                end.Property(x => x.Bairro)
                    .HasColumnType("varchar(250)");

                end.Property(x => x.Cep)
                    .HasColumnType("varchar(8)");

                end.Property(x => x.Cidade)
                    .HasColumnType("varchar(350)");

                end.Property(x => x.Complemento)
                    .HasColumnType("varchar(200)");

                end.Property(x => x.Estado)
                    .HasColumnType("varchar(2)");

                end.Property(x => x.Logradouro)
                    .HasColumnType("varchar(350)");
            });

            builder.ToTable("Clientes");
        }
    }
}
