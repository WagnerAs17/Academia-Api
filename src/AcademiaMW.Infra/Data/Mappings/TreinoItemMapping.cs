using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    class TreinoItemMapping : IEntityTypeConfiguration<TreinoItem>
    {
        public void Configure(EntityTypeBuilder<TreinoItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(x => x.Repeticao).IsRequired();

            builder.HasOne(x => x.Treino)
                .WithMany(x => x.TreinoItens);

            builder.ToTable("TreinoItens");
        }
    }
}
