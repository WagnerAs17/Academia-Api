using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Data.Mappings
{
    public class PermissaoMapping : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClaimType)
                .IsRequired();

            builder.Property(x => x.ClaimValue)
                .IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Permissoes);

            builder.ToTable("Permissoes");
        }
    }
}
