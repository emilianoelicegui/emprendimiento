
using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class UserConfig
    {
        public UserConfig (EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.Rol).WithMany(r => r.Users).HasForeignKey(x => x.IdRol);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
