
using Domain.Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Layer.Config
{
    public class CompanyConfig
    {
        public CompanyConfig(EntityTypeBuilder<Company> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.User).WithMany(r => r.Companys).HasForeignKey(x => x.IdUser);
            entityBuilder.Property(x => x.NameFantasy).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.Cuit).IsRequired();
            entityBuilder.Property(x => x.CodePostal).IsRequired();
            entityBuilder.Property(x => x.Street).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.Number).IsRequired();
        }
    }
}
