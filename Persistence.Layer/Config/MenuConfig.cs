
using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Layer.Config
{
    public class MenuConfig
    {
        public MenuConfig (EntityTypeBuilder<Menu> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Url).IsRequired();
            entityBuilder.Property(x => x.Icon).IsRequired();
        }
    }
}
