using System;
using Microsoft.EntityFrameworkCore;
using Tenders.Core.Interfaces;

namespace Tenders.Infrastructure.Data.Repositories
{
    public sealed class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public EntityFrameworkUnitOfWork()
            : this(new Persistence.TenderDbContext())
        {
        }

        public EntityFrameworkUnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DbContext Context => _context;

        private void CloseContext()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        #region IDisposable Methods

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    CloseContext();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IUnitOfWork Members

        public void Save()
        {
            if (_context == null)
                throw new InvalidOperationException("Context has not been initialized.");
            _context.SaveChanges();
        }

        #endregion
    }
}
