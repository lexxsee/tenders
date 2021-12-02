using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tenders.Core.Interfaces;

namespace Tenders.Infrastructure.Data.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public EntityFrameworkRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _objectSet = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {

            return _objectSet;
        }

        public virtual void Add(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _objectSet.Add(entity);
        }

        public virtual void Remove(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _objectSet.Remove(entity);
        }

        public DbContext Context { get; }
    }
}
