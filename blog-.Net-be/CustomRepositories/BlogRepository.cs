using blog_.Net_be.data;
using blog_.Net_be.Models;

namespace blog_.Net_be.CustomRepositories
{
    public class BlogRepository:IBlogRepository
    {
        private readonly BlogDbContext dbContext;
        public BlogRepository(BlogDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Blog?> updateById(Guid id ,Blog blog)
        {
         var newBlogs= await dbContext.Blogs.FindAsync(id);
        if(newBlogs == null)
            {
                return null;
            }
            newBlogs.Author = blog.Author;
            newBlogs.Description = blog.Description;
            newBlogs.CategoryId = blog.CategoryId;
            newBlogs.Title = blog.Title;
           await dbContext.SaveChangesAsync();
            return newBlogs;
        }
    }
}
