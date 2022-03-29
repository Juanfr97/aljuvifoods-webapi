using aljuvifoods_webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aljuvifoods_webapi.Repository
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasIndex(x => x.OrderId).HasDatabaseName("UI_OrderId").IsUnique();
            builder.HasOne(typeof(Order)).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ProductId).HasDatabaseName("UI_ProductId").IsUnique();
            builder.HasOne(typeof(Product)).WithMany().OnDelete(DeleteBehavior.Restrict);


        }
    }
}
