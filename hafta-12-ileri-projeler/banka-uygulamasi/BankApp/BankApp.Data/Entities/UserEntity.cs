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
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public bool IsTwoFactorEnable { get; set; } = false;

        //Navigation Properties

        public UserTwoFactorEntity TwoFactor { get; set; }
        public ICollection<UserActivity> Activities { get; set; } = new List<UserActivity>();
        public ICollection<MoneyTransactionEntity> SenderTransactions { get; set; } = new List<MoneyTransactionEntity>();
        public ICollection<MoneyTransactionEntity> ReceiverTransactions { get; set; } = new List<MoneyTransactionEntity>();
        public ICollection<AccountEntity> Accounts { get; set; } = new List<AccountEntity>();

        public ICollection<BillEntity> Bills { get; set; } = new List<BillEntity>();
    } // end of class UserEntity

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.BirthDate)
                   .IsRequired()
                   .HasColumnType("date");

            builder.Property(x => x.UserType)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValue(UserType.costumer)
                   .HasConversion<string>();

            builder.Property(x => x.FirstName)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11);

            builder.HasIndex(x => x.PhoneNumber)
                    .IsUnique();

            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                    .IsUnique();

            builder.Property(x => x.Password)
                    .IsRequired()
                    .HasMaxLength(256); // Hashed password length

            builder.Property(x => x.IsTwoFactorEnable)
                    .HasDefaultValue(false)
                    .IsRequired();

            base.Configure(builder);
        }
    }
}
