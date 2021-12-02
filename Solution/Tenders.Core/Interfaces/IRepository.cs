using System.Threading.Tasks;

namespace Tenders.Core.Interfaces
{
    public interface IRepository<T>
    {
        System.Linq.IQueryable<T> All();
        void Add(T entity);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}
