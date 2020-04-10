
using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Layer.Config
{
    public class MenuConfig
    {
        public MenuConfig (EntityTypeBuilder<Menu> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombre).HasMaxLength(150);
        }
    }
}
