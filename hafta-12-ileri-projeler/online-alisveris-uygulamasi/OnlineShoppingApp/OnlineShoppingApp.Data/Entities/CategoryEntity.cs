using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string CategoryName { get; set; }

        // Navigation properties
        public ICollection<ProductEntity> Products { get; set; }
    } //categoryclass done

    public class CategoryConfiguration : BaseConfiguration<CategoryEntity>
    {
        override public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
           
            builder.Property(x => x.CategoryName)
                   .IsRequired()
                   .HasMaxLength(100);

            base.Configure(builder);

        }

    } // CategoryConfiguration class done
}
