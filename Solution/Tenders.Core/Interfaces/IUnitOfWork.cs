using System;

namespace Tenders.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
