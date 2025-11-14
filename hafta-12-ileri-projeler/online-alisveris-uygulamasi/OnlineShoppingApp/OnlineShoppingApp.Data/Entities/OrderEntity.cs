using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShoppingApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }



        public OrderStatus Status { get; set; }

        // Navigation properties
        public ICollection<OrderProductEntity> OrderProducts { get; set; }
       

    } //Orderclass done

    public class OrderConfiguration : BaseConfiguration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(x=> x.OrderDate)
                    .IsRequired();

            builder.Property(x => x.TotalAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

            builder.HasOne(x=> x.User)
                    .WithMany(u=> u.Orders)
                     .HasForeignKey(x => x.UserId)
                     .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Status)
                    .IsRequired()
                    .HasConversion(
                        v => v.ToString(),
                        v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

            base.Configure(builder);

        }
    } // OrderConfiguration class done
}
