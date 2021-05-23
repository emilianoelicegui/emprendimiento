using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class SpendingTypeConfig
    {
        public SpendingTypeConfig(EntityTypeBuilder<SpendingType> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Description).HasMaxLength(150).IsRequired();
        }    
    }
}