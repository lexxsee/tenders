using System;
using System.Threading.Tasks;

namespace Tenders.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
