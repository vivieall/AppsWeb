using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.Database.Config
{
    public class OrderDetailConfig
    {
        public OrderDetailConfig(EntityTypeBuilder<OrderDetail> entityBuilder) 
        {
            entityBuilder.Property(x => x.OrderId).HasMaxLength(20);
        }
    }
}
