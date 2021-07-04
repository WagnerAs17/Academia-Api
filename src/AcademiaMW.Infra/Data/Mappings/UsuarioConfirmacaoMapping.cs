using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Infra.Data.Mappings
{
    public class UsuarioConfirmacaoMapping : IEntityTypeConfiguration<UsuarioConfirmacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioConfirmacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo).HasColumnType("varchar(6)");

            builder.ToTable("UsuarioConfirmacao");
        }
    }
}
