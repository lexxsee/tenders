using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tenders.Core.Interfaces;

namespace Tenders.Infrastructure.Data.Repositories
{
    public sealed class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public EntityFrameworkRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _objectSet = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return _objectSet;
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _objectSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _objectSet.AddAsync(entity);
        }

        public void Edit(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
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