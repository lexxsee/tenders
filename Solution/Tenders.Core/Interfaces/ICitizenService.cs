using Tenders.Core.DTOs;

namespace Tenders.Core.Interfaces
{
    public interface ICitizenService
    {
        void Add(CitizenRequestDto citizenRequestDto);
        void Remove(int id);
    }
}