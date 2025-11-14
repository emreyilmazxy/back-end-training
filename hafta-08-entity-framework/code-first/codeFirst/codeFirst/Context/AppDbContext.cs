using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=PatikaFirstDB;Username=postgres;Password=1907146ey");
            }
        }
    }
}
