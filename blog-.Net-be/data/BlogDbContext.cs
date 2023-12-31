﻿using blog_.Net_be.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_.Net_be.data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().Navigation(c => c.Category).AutoInclude();
            modelBuilder.Entity<Blog>().Navigation(c=>c.Image).AutoInclude();
            modelBuilder.Entity<Blog>().Property(b => b.CreatedDate).HasDefaultValueSql("getdate()");

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images {  get; set; }
    }
}
