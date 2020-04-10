
using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Layer.Config
{
    class MenuRolConfig
    {
        public MenuRolConfig(EntityTypeBuilder<MenuRol> entityBuilder)
        {
            entityBuilder.Property(x => x.MenuId).IsRequired();
            entityBuilder.Property(x => x.RolId).IsRequired();
        }
    }
}
