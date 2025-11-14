using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Context
{
    public class OnlineShoppingDbContext : DbContext
    {
        public OnlineShoppingDbContext(DbContextOptions<OnlineShoppingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlineShoppingDbContext).Assembly); // Automatically apply all configurations in the assembly

            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity
            { 
              Id = 1,
              MaintenanceMode = false,

            });

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderProductEntity> OrderProducts { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SettingEntity> Settings { get; set; }


    }
}
