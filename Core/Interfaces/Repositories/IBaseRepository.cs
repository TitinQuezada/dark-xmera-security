using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        void Create(T entity);

        void Delete(string entityId);

        Task<T> FindAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        Task SaveAsync();
    }
}
