
using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class MenuRolConfig
    {
        public MenuRolConfig (EntityTypeBuilder<MenuRol> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.Rol).WithMany(r => r.MenuRoles).HasForeignKey(x => x.IdRol).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(x => x.Menu).WithMany(r => r.MenuRoles).HasForeignKey(x => x.IdMenu).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
