﻿using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Emprendimiento.API.Repositories.Config;

namespace Emprendimiento.API.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base (options)
        {

        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuRol> MenuRol { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<SpendingType> SpendingTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DolarBlueValue> DolarBlueValues { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ItemSale> ItemSales { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new MenuConfig(modelBuilder.Entity<Menu>());
            new MenuRolConfig(modelBuilder.Entity<MenuRol>());
            new RolConfig(modelBuilder.Entity<Rol>());
            new UserConfig(modelBuilder.Entity<User>());
            new ProductConfig(modelBuilder.Entity<Product>());
            new ProviderConfig(modelBuilder.Entity<Provider>());
            new CompanyConfig(modelBuilder.Entity<Company>());
            new SpendingConfig(modelBuilder.Entity<Spending>());
            new SpendingTypeConfig(modelBuilder.Entity<SpendingType>());
            new ClientConfig(modelBuilder.Entity<Client>());
            new DolarBlueValueConfig(modelBuilder.Entity<DolarBlueValue>());
            new SaleConfig(modelBuilder.Entity<Sale>());
            new ItemSaleConfig(modelBuilder.Entity<ItemSale>());
            new PaymentConfig(modelBuilder.Entity<Payment>());
            new StockConfig(modelBuilder.Entity<Stock>());
        }
    }
}
