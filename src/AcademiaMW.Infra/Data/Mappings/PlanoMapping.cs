using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.HasMany(x => x.PlanoValores)
                .WithOne(x => x.Plano)
                .HasForeignKey(x => x.PlanoId);

            builder.ToTable("Planos");
        }
    }
}
