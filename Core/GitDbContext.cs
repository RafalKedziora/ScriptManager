using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class GitDbContext : DbContext
    {
        public GitDbContext(DbContextOptions<GitDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}