using Microsoft.EntityFrameworkCore.Storage;
using OkulDeneme.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OkulDenemeDbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(OkulDenemeDbContext context)
        {
            _context = context; 
        }
        public async Task BeginTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.DisposeAsync();
            }
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    } // end of UnitOfWork class
}
