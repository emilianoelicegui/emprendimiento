using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class DolarBlueValueConfig
    {
        public DolarBlueValueConfig(EntityTypeBuilder<DolarBlueValue> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.LastUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            entityBuilder.Property(x => x.Date)
                .HasColumnType("date")
                .IsRequired();
            entityBuilder.Property(x => x.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
