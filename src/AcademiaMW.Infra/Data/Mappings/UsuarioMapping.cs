using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaMW.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            // 1 : N =>  Usuario : Permissao
            builder.HasMany(x => x.Permissoes)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);

            builder.ToTable("Usuarios");
        }
    }
}
