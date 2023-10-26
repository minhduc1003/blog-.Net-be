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
        public async Task<T?> findById(Guid id)
        {
            var data = await DbSet.FindAsync(id);
            if(data == null)
            {
                return null;
            }
            return data;
        }
        public async Task<bool> updateById(Guid id,T entity)
        {
            var data = await DbSet.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            else
            {
                DbContext.Entry(entity).State = EntityState.Modified;
                DbSet.Attach(entity);
            }
            return true;
        }
        public async Task<T> create(T entity)
        {
             await DbSet.AddAsync(entity);
            return entity;
        }
        public async Task<T?> delete(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            if(entity == null)
            {
                return null;
            }
                DbSet.Remove(entity);
            return  entity ;
        }
        
    }
}
