using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.Database.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder) 
        {
            entityBuilder.Property(x => x.ClientNumber).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entityBuilder.HasOne(x => x.Country)
                         .WithMany(x => x.Clients)
                         .HasForeignKey(x => x.Country_Id);

            entityBuilder.HasData(
                new Client { 
                    ClientId = 1,
                    ClientNumber = "100000001",
                    Name = "Henry"
                },
                new Client
                {
                    ClientId = 2,
                    ClientNumber = "100000002",
                    Name = "Juan"
                }
            );
        }
    }
}
