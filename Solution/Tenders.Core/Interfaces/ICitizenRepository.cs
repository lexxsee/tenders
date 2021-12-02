using System.Collections.Generic;
using Tenders.Core.Entities;

namespace Tenders.Core.Interfaces
{
    public interface ICitizenRepository : IRepository<Citizen>
    {
        ICollection<Citizen> GetAll();
        Citizen GetByKey(int id);
    }
}