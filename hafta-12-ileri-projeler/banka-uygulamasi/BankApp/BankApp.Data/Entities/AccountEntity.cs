using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class AccountEntity : BaseEntity
    {
        public int UserId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }            // account balance
        public string Currency { get; set; }            // ( TRY, USD) a like
        public bool IsActive { get; set; }

        



        // Navigation property
        public UserEntity User { get; set; }
    } // end of class AccountEntity

    public class AccountConfiguration : BaseConfiguration<AccountEntity>
    {
        public override void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.Property(x => x.AccountNumber)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.HasIndex(x => x.AccountNumber)
                   .IsUnique();


            builder.Property(x => x.Balance)
                    .IsRequired()
                    .HasPrecision(18, 2);

            builder.Property(x => x.Currency)
                   .IsRequired()
                   .HasMaxLength(3);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Accounts)
                   .HasForeignKey(x => x.UserId);

            builder.Property(x => x.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);


            base.Configure(builder);
        }
    }
}
