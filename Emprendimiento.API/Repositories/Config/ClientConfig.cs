using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprendimiento.API.Repositories.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.Property(x => x.Surname).IsRequired();
            entityBuilder.Property(x => x.Dni).IsRequired();
            entityBuilder.Property(x => x.Cuit).IsRequired();
            entityBuilder.Property(x => x.CodArea).IsRequired();
            entityBuilder.Property(x => x.Phone).IsRequired();
            entityBuilder.HasOne(x => x.Company).WithMany(r => r.Clients).HasForeignKey(x => x.IdCompany).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
