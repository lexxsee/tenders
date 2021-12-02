using System;
using Microsoft.EntityFrameworkCore;
using Tenders.Core.Interfaces;
using Tenders.Infrastructure.Data.Persistence;

namespace Tenders.Infrastructure.Data.Repositories
{
    public class EntityFrameworkUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext _context;

        public EntityFrameworkUnitOfWorkFactory()
            : this(new TenderDbContext())
        {
        }

        public EntityFrameworkUnitOfWorkFactory(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region IUnitOfWorkFactory Members

        public virtual IUnitOfWork Create()
        {
            if (_context == null)
                throw new InvalidOperationException("Context has not been initialized.");
            return new EntityFrameworkUnitOfWork(_context);
        }
        #endregion
    }
}
