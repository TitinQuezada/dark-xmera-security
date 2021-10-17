using Core.Enums;
using Core.Interfaces;
using Core.Interfaces.Repositories;
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
            StatusModel status = _applicationContext.Statuses.FirstOrDefault(status => status.Id == (int)Statuses.Active);
            entity.Status = status;

            _set.Add(entity);
        }

        void IBaseRepository<T>.Delete(string entityId)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            T entity = queryable.FirstOrDefault(entity => entity.Id == entityId);
            StatusModel status = _applicationContext.Statuses.FirstOrDefault(status => status.Id == (int)Statuses.Inactive);

            entity.Status = status;
        }

        async Task<IEnumerable<T>> IBaseRepository<T>.FindAllAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            queryable = queryable.Include(entity => entity.Status);

            return await queryable.Where(condition).Where(entity => entity.Status.Id == (int)Statuses.Active).ToListAsync();
        }

        async Task<T> IBaseRepository<T>.FindAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            queryable = queryable.Include(entity => entity.Status);

            return await queryable.Where(condition).Where(entity => entity.Status.Id == (int)Statuses.Active).FirstOrDefaultAsync();
        }

        async Task<IEnumerable<T>> IBaseRepository<T>.GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            queryable = queryable.Include(entity => entity.Status);

            return await queryable.Where(entity => entity.Status.Id == (int)Statuses.Active).ToListAsync();
        }

        async Task IBaseRepository<T>.SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
