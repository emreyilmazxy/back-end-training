using Microsoft.EntityFrameworkCore;
using RelationTable.Models;

namespace RelationTable.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                         .HasKey(sc => new { sc.StudentId,sc.CourseId });
        }
    }
} 
