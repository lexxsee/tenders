namespace Tenders.Core.Interfaces
{
    public interface IRepository<T>
    {
        System.Linq.IQueryable<T> All();
        void Add(T entity);
        void Remove(T entity);
    }
}
