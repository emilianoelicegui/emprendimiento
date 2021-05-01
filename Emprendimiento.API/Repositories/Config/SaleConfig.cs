using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories.Config
{
    public class SaleConfig
    {
        public SaleConfig(EntityTypeBuilder<Sale> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.IdClient).IsRequired();
            entityBuilder.Property(x => x.IdCompany).IsRequired();
            entityBuilder.Property(x => x.Amount).IsRequired();
            entityBuilder.Property(x => x.MethodPayment).IsRequired();
            entityBuilder.Property(x => x.Date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            entityBuilder.HasOne(x => x.Client).WithMany(r => r.Sales).HasForeignKey(x => x.IdClient).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(u => u.Company).WithMany(u => u.Sales).HasForeignKey(x => x.IdCompany).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
