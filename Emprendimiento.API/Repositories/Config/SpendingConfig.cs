using Domain.Layer;
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
            entityBuilder.Property(x => x.Type).IsRequired();
            entityBuilder.Property(x => x.Amount).IsRequired();
            entityBuilder.HasOne(x => x.Company).WithMany(r => r.Spendings).HasForeignKey(x => x.IdCompany);
        }
    }
}
