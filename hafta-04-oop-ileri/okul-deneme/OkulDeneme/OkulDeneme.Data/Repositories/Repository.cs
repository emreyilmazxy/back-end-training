using Microsoft.EntityFrameworkCore;
using OkulDeneme.Data.Context;
using OkulDeneme.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly OkulDenemeDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(OkulDenemeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _context.AddAsync(entity);

        }

        public async Task DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.MotifiedDate = DateTime.Now;
            _context.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            entity.IsDeleted = true;
            entity.MotifiedDate = DateTime.Now;
            _context.Update(entity);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _dbSet.AsNoTracking();
            return predicate == null ? query : query.Where(predicate);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().
                          Where(predicate) 
                          .FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = _dbSet.FindAsync(id);
            return await entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.MotifiedDate = DateTime.Now;
            _context.Update(entity);
        }
    
    
    }// end of Repository class
}
