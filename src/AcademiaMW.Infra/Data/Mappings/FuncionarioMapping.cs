using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasColumnType("varchar(250)");

            builder.OwnsOne(f => f.Email, e =>
            {
                e.Property(x => x.Endereco)
                    .HasColumnType("varchar(300)");
            });

            builder.OwnsOne(f => f.CPF, c =>
            {
                c.Property(x => x.Numero)
                    .HasColumnType("varchar(11)");
            });

            builder.ToTable("Funcionarios");
        }
    }
}
