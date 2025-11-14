using BankApp.Data.Context;
using BankApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BankAppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(BankAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }


        public async Task DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.ModifedDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            entity.IsDeleted = true;
            entity.ModifedDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _dbSet;
            return predicate == null ? query : query.Where(predicate);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
            
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.ModifedDate = DateTime.Now;
            _dbSet.Update(entity);

        }
    } // end of class Repository
}
