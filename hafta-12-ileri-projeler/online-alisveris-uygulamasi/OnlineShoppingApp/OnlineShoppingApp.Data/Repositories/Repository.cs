using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Data.Context;
using OnlineShoppingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly OnlineShoppingDbContext _db;
        private readonly DbSet<TEntity> _DbSet;

        public Repository(OnlineShoppingDbContext db)
        {
            _db = db;
            _DbSet = _db.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _DbSet.AddAsync(entity);
           
        }


        public async Task DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
             _DbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _DbSet.FindAsync(id);
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            _DbSet.Update(entity);
        }

        public  IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _DbSet.AsNoTracking();
            return predicate == null ? query : query.Where(predicate);

        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _DbSet
                 .AsNoTracking()
                .Where(predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _DbSet.Update(entity); 
          
        }
    } //Repository class done
}
