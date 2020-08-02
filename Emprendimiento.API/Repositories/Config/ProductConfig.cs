
using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Emprendimiento.API.Repositories.Config
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityBuilder)
        {   
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.Company).WithMany(r => r.Products).HasForeignKey(x => x.IdCompany);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Price).IsRequired().HasColumnType("Decimal(10,5)");
            entityBuilder.Property(x => x.IsDolar).IsRequired();
        }
    }
}
