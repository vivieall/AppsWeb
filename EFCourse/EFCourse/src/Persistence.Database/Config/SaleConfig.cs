using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.Database.Config
{
    public class SaleConfig
    {
        public SaleConfig(EntityTypeBuilder<Sale> entityBuilder) 
        {
            entityBuilder.HasKey(x => new { 
                x.Year,
                x.Month
            });
        }
    }
}
