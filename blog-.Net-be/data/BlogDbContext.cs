using blog_.Net_be.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_.Net_be.data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
