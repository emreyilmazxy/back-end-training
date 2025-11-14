using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class OrderProductEntity : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }


        // Navigation properties
        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
    } // orderproductclass done

    public class OrderProductConfiguration : BaseConfiguration<OrderProductEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.Ignore(x => x.Id);

            builder.HasKey(x => new { x.OrderId, x.ProductId });
             
            builder.HasOne(x => x.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(x => x.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                 .WithMany(p => p.OrderProducts)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
           
            builder.Property(x => x.Quantity)
                    .IsRequired();  
          

            base.Configure(builder);
        }
    } // OrderProductConfiguration class done
}
