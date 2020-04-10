using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Layer.Config
{
    public class RolConfig
    {
        public RolConfig(EntityTypeBuilder<Rol> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombre).IsRequired();
            entityBuilder.Property(x => x.Nombre).HasMaxLength(100);
        }
    }
}
