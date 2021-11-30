using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    public class TreinoMapping : IEntityTypeConfiguration<Treino>
    {
        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(1000)");

            builder.ToTable("Treinos");
        }
    }
}
