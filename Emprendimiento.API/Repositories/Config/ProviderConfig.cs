﻿
using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class ProviderConfig
    {
        public ProviderConfig(EntityTypeBuilder<Provider> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.User).WithMany(r => r.Providers).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.Telephone).IsRequired();
            entityBuilder.Property(x => x.Cuit).IsRequired();
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        }
    }
}
