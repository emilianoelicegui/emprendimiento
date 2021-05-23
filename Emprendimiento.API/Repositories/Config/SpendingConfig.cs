using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories.Config
{
    public class SpendingConfig
    {
        public SpendingConfig(EntityTypeBuilder<Spending> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Amount).IsRequired();
            entityBuilder.Property(x => x.Date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            entityBuilder.HasOne(x => x.Company).WithMany(r => r.Spendings).HasForeignKey(x => x.IdCompany).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(x => x.SpendingType).WithMany(r => r.Spendings).HasForeignKey(x => x.IdSpendingType).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
