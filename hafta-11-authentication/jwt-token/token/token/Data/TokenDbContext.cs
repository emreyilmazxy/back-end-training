
using Microsoft.EntityFrameworkCore;
using token.Entities;

namespace token.Data
{
    public class TokenDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public TokenDbContext(DbContextOptions<TokenDbContext> options ) : base(options)
        {
        }

      
       
    }
}
