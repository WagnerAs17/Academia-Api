using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    public class PlanoValorMapping : IEntityTypeConfiguration<PlanoValor>
    {
        public void Configure(EntityTypeBuilder<PlanoValor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Plano)
                .WithMany(x => x.PlanoValores);

            builder.ToTable("PlanoValores");
        }
    }
}
