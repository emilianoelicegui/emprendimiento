using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories.Config
{
    public class ItemSaleConfig
    {
        public ItemSaleConfig(EntityTypeBuilder<ItemSale> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.IdSale).IsRequired();
            entityBuilder.HasOne(x => x.Sale).WithMany(r => r.ItemSales).HasForeignKey(x => x.IdSale).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
