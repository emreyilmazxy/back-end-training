using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(int id);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> predicate);

       IQueryable<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate = null);

    } // IRepository interface done
}
