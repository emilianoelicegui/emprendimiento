
using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class MenuConfig
    {
        public MenuConfig (EntityTypeBuilder<Menu> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Url).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Icon).IsRequired().HasMaxLength(100);
        }
    }
}
