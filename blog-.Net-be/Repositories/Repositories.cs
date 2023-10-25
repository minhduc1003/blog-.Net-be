using blog_.Net_be.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace blog_.Net_be.Repositories
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
       public Repositories() { }
        public DbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        public DbContext DbContext { get; set; }
        public async Task<IEnumerable<T>> getAll()
        {
            var data = await DbSet.ToListAsync();
            return data;
        }
        public async Task<T> findById(Guid id)
        {
            var data = await DbSet.FirstOrDefaultAsync(c =>
             ((Guid)c.GetType().GetProperty("Id").GetValue(c) == id));
            return data;
        }
        public async Task<bool> update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbSet.Attach(entity);
            return true;
        }
        public async Task<T> create(T entity)
        {
             await DbSet.AddAsync(entity);
            return entity;
        }
        public async Task<T> delete(Guid id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(c =>
             ((Guid)c.GetType().GetProperty("Id").GetValue(c) == id));
            DbSet.Remove(entity);
            return  entity ;
        }

    }
}
