using Microsoft.EntityFrameworkCore.Storage;
using OnlineShoppingApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShoppingDbContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(OnlineShoppingDbContext db)
        {
            _db = db;
        }
        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync(); 
            }

            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();

        }

        public void Dispose()
        {
             _db.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    } // UnitOfWork class done
}
