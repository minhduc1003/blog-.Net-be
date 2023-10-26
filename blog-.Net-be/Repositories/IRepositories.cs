using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog_.Net_be.Repositories
{
    public interface IRepositories<T> where T : class
    {
        DbSet<T> DbSet { get; }
        DbContext DbContext { get; set; }
        public Task<IEnumerable<T>> getAll();
        public Task<T?> findById(Guid id);
        public Task<bool> updateById(Guid id, T entity);
        public Task<T> create(T entity);
        public Task<T?> delete(Guid id);

    }
}
