using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.Database.Config
{
    public class OrderConfig
    {
        public OrderConfig(EntityTypeBuilder<Order> entityBuilder) 
        {
            entityBuilder.Property(x => x.OrderId).HasMaxLength(20);
        }
    }
}
