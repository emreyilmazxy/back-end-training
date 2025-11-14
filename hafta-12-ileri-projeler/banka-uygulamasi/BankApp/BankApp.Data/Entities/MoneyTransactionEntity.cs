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
    public class MoneyTransactionEntity : BaseEntity
    {
        public int? SenderUserId { get; set; }
        public int? ReceiverUserId { get; set; }

        public int? SenderAccountId { get; set; }
        public int? ReceiverAccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }    // (Deposit, Withdrawal, Transfer)
        public DateTime Timestamp { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        public UserEntity SenderUser { get; set; }
        public UserEntity ReceiverUser { get; set; }
        public AccountEntity SenderAccount { get; set; }
        public AccountEntity ReceiverAccount { get; set; }


    } // end of class MoneyTransactionEntity

    public class MoneyTransactionConfiguration : BaseConfiguration<MoneyTransactionEntity>
    {
        public override void Configure(EntityTypeBuilder<MoneyTransactionEntity> builder)
        {
            builder.Property(x => x.Amount)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.ToTable(t => t.HasCheckConstraint("CK_MoneyTransactions_Amount_NonNegative", "[Amount] >= 0"));

            builder.Property(x => x.TransactionType)
                   .HasConversion<string>()
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Timestamp)
                     .IsRequired();
            builder.Property(x => x.Description)
                     .IsRequired(false)
                     .HasMaxLength(250);

            builder.HasOne(x => x.SenderUser)
                     .WithMany(x => x.SenderTransactions)
                     .HasForeignKey(x => x.SenderUserId)
                     .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReceiverUser)
                        .WithMany(x => x.ReceiverTransactions)
                        .HasForeignKey(x => x.ReceiverUserId)
                        .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SenderAccount)
                   .WithMany()
                   .HasForeignKey(x => x.SenderAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReceiverAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ReceiverAccountId)
                   .OnDelete(DeleteBehavior.Restrict);


            base.Configure(builder);
        }
    }
}
