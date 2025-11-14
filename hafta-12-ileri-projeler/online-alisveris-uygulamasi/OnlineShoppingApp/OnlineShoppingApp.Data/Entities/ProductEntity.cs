using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        // Navigation properties
        public ICollection<OrderProductEntity> OrderProducts { get; set; }
        public CategoryEntity Category { get; set; }

    } // productclass done

   public class ProductConfiguration : BaseConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Price)
                    .IsRequired()
                     .HasColumnType("decimal(18,2)");

            builder.Property(x => x.StockQuantity)
                    .IsRequired()
                    .HasDefaultValue(0);

            builder.HasOne(x => x.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    } // ProductConfiguration class done
}
