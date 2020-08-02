using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class RolConfig
    {
        public RolConfig(EntityTypeBuilder<Rol> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        }
    }
}
