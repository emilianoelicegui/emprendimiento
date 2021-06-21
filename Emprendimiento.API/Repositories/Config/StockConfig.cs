using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories.Config
{
    public class StockConfig
    {
        public StockConfig(EntityTypeBuilder<Stock> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Units).IsRequired();
            entityBuilder.Property(x => x.Date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            entityBuilder.HasOne(x => x.User).WithMany(r => r.Stocks).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(x => x.Product).WithMany(r => r.Stocks).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(x => x.Provider).WithMany(r => r.Stocks).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
