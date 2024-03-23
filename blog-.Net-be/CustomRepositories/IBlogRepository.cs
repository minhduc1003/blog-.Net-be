using blog_.Net_be.data;
using blog_.Net_be.Models;

namespace blog_.Net_be.CustomRepositories
{
    public interface IBlogRepository
    {
        public Task<Blog?> updateById(Guid id, Blog blog);

        
    }
}
