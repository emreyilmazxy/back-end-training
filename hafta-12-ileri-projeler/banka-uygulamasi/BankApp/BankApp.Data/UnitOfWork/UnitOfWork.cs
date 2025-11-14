using BankApp.Data.Context;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankAppDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BankAppDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync() // method beginning
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }

            _transaction = await _context.Database.BeginTransactionAsync(); 
        }

        public async Task CommitTransactionAsync() // method beginning
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task RollbackTransactionAsync() // method beginning
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public Task<int> SaveChangesAsync() // method beginning
        {
            return _context.SaveChangesAsync();
        }
    }// end of class UnitOfWork
}
