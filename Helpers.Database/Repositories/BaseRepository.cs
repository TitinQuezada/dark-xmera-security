using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Helpers.Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly DarkXmeraSecurityDbContext _applicationContext;
        private DbSet<T> _set;

        public BaseRepository(DarkXmeraSecurityDbContext applicationContext)
        {
            _applicationContext = applicationContext;
            _set = applicationContext.Set<T>();
        }

        void IBaseRepository<T>.Create(T entity)
        {
            _set.Add(entity);
        }

        void IBaseRepository<T>.Delete(string entityId)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            T entity = queryable.FirstOrDefault(entity => entity.Id == entityId);

            _set.Remove(entity);
        }

        async Task<IEnumerable<T>> IBaseRepository<T>.FindAllAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return await queryable.Where(condition).ToListAsync();
        }

        async Task<T> IBaseRepository<T>.FindAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return await queryable.Where(condition).FirstOrDefaultAsync();
        }

        async Task<IEnumerable<T>> IBaseRepository<T>.GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return await queryable.ToListAsync();
        }

        async Task IBaseRepository<T>.SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
