using BankApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class BillEntity : BaseEntity
    {
        public int UserId { get; set; }                
        public BillType BillType { get; set; }           
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }          
        public bool IsPaid { get; set; }               
        public DateTime? PaymentDate { get; set; }     

        // Navigation property
        public UserEntity User { get; set; }
    }// end of class BillEntity

    public class BillConfiguration : BaseConfiguration<BillEntity>
    {
        public override void Configure(EntityTypeBuilder<BillEntity> builder)
        {
           

            builder.Property(x => x.BillType)
                    .HasConversion<string>()  
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Amount)
                     .IsRequired()
                     .HasPrecision(18, 2);

            builder.ToTable(t => t.HasCheckConstraint("CK_Bills_Amount_NonNegative", "[Amount] >= 0"));

            builder.Property(x => x.DueDate)
                   .IsRequired();

            builder.HasOne(x => x.User)
                    .WithMany(x=>x.Bills)
                    .HasForeignKey(x => x.UserId);



            base.Configure(builder);
        }
    }
}
