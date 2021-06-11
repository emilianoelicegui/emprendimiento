using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories.Config
{
    public class PaymentConfig
    {
        public PaymentConfig(EntityTypeBuilder<Payment> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            entityBuilder.HasOne(x => x.Client).WithMany(r => r.Payments).HasForeignKey(x => x.IdClient).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.Property(x => x.Datetime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
