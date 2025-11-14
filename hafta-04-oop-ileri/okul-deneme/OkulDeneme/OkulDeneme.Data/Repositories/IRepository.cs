using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate = null);

        Task AddAsync(TEntity entity);  
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(int id);

        Task <TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);



    } // end of IRepository interface
    
}
