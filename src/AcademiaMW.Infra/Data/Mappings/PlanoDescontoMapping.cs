using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    public class PlanoDescontoMapping : IEntityTypeConfiguration<PlanoDesconto>
    {
        public void Configure(EntityTypeBuilder<PlanoDesconto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Plano)
                .WithMany(x => x.PlanoDescontos);

            builder.ToTable("PlanoDescontos");
        }
    }
}
