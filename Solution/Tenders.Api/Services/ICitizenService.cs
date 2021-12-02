using System.Collections.Generic;
using System.Threading.Tasks;
using Tenders.Core.DTOs;

namespace Tenders.Api.Services
{
    public interface ICitizenService
    {
        Task<IEnumerable<CitizenDto>> GetAllAsync();

        Task<IEnumerable<CitizenDto>> FindAsync(CitizenFilterDto filter);
        Task<CitizenDto> FindByDocumentAsync(CitizenDocumentFilterDto filter);
        Task AddAsync(CitizenRequestDto citizenRequestDto);
        Task EditAsync(int id, CitizenRequestDto citizenRequestDto);
        Task RemoveAsync(int id);
        Task<string> ExportToCvsAsync();
        Task ImportFromCvsAsync(string raw);
    }
}