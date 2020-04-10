using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Persistence.Layer.Config;

namespace Persistence.Layer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base (options)
        {

        }

        public DbSet<Menu> Menues { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new MenuConfig(modelBuilder.Entity<Menu>());
            new RolConfig(modelBuilder.Entity<Rol>());
        }
    }
}
