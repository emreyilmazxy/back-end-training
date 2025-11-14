using BankApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Context
{
    public class BankAppDbContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MoneyTransactionEntity> MoneyTransactions { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserTwoFactorEntity> UserTwoFactors { get; set; }
        public DbSet<BillEntity> Bills { get; set; }

        public BankAppDbContext(DbContextOptions<BankAppDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAppDbContext).Assembly); // Automatically apply all configurations from the current assembly
            
            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity
            {
                Id = 1,
                MaintenanceMode = false,

            });

            base.OnModelCreating(modelBuilder);
            
        }
  
    
    }// end of class BankAppDbContext
}
