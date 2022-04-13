using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.DAL.Abstractions
{
    public class BaseRepository<T> where T : class
    {
        protected readonly OrderApiContext Context;

        public BaseRepository(OrderApiContext context)
        {
            Context = context;
        }

        public async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
