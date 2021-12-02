using Tenders.Core.DTOs;

namespace Tenders.Api.Services
{
    public interface ICitizenService
    {
        void Add(CitizenRequestDto citizenRequestDto);
        void Remove(int id);
    }
}