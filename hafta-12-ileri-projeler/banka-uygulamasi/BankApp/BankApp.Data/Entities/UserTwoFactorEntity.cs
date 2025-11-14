using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class UserTwoFactorEntity : BaseEntity
    {
        public int UserId { get; set; }

        public string OtpCode { get; set; }          
        public DateTime ExpireAt { get; set; }     
        public bool IsUsedCode { get; set; }           //otp code  was it used ?
        public string Provider { get; set; }       // "SMS", "Email", "Authenticator" like

        public string? TwoFactorSecretKey { get; set; } // for authenticator apps

        //Navigation Property
        public UserEntity User { get; set; }
    } // end of class UserTwoFactorEntity

    public class UserTwoFactorConfiguration : BaseConfiguration<UserTwoFactorEntity>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserTwoFactorEntity> builder)
        {
           builder.Property(x => x.OtpCode)
                    .IsRequired()
                    .HasMaxLength(10);

            builder.Property(x => x.ExpireAt)
                    .IsRequired();

            builder.Property(x => x.IsUsedCode)
                    .IsRequired();

            builder.Property(x => x.Provider)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.TwoFactorSecretKey)
                    .IsRequired(false)
                    .HasMaxLength(100);

            builder.HasOne(x => x.User)
                    .WithOne(x => x.TwoFactor)
                    .HasForeignKey<UserTwoFactorEntity>(x => x.UserId);

            base.Configure(builder);
        }
    }


}
