using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Context
{
    public class OkulDenemeDbContext : DbContext
    {
        public OkulDenemeDbContext(DbContextOptions<OkulDenemeDbContext> options): base(options)
        {
        }
        // DbSet properties for your entities
        public DbSet<Entities.StudentEntity> Students { get; set; }
        public DbSet<Entities.TeacherEntity> Teachers { get; set; }
        public DbSet<Entities.CourseEntity> Courses { get; set; }
        public DbSet<Entities.StudentCoursesEntity> StudentCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OkulDenemeDbContext).Assembly); // Automatically apply configurations from the assembly

            base.OnModelCreating(modelBuilder);
            // Additional model configuration can go here
        }
    } // end of OkulDenemeDbContext class
}
