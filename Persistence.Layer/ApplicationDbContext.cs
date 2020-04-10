﻿using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Repositories.Layer.Config;

namespace Repositories.Layer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base (options)
        {

        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new MenuConfig(modelBuilder.Entity<Menu>());
            new RolConfig(modelBuilder.Entity<Rol>());
            new UserConfig(modelBuilder.Entity<User>());
        }
    }
}
