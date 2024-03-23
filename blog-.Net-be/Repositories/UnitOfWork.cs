using blog_.Net_be.data;
using blog_.Net_be.Models;

namespace blog_.Net_be.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public BlogDbContext DbContext { get;  }
        public IRepositories<Blog> BlogRepository { get;  }
        public IRepositories<Category> CategoryRepository { get;  }
        public UnitOfWork(BlogDbContext context, IRepositories<Blog> blog, IRepositories<Category> category) { 
            DbContext = context;
            BlogRepository = blog;
            CategoryRepository = category;
            BlogRepository.DbContext = DbContext;
            CategoryRepository.DbContext = DbContext;
        }
        public async Task<int> SaveChanges() {
            return await DbContext.SaveChangesAsync();  
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
