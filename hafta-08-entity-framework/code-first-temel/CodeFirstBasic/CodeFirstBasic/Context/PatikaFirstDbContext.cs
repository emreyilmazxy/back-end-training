using CodeFirstBasic.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstBasic.Context
{
    public class PatikaFirstDbContext : DbContext
    {
        public PatikaFirstDbContext(DbContextOptions<PatikaFirstDbContext> options)
        : base(options)
        {}
        DbSet<MovieEntity> Movies { get; set; }
        DbSet<GameEntity> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameEntity>(entity =>
            { 
                entity.ToTable("Games");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Platform)
                       .IsRequired()
                       .HasMaxLength(50);
            });

            modelBuilder.Entity<MovieEntity>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.ReleaseYear)
                    .IsRequired();
            });



        }

    }
}
