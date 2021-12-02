using AutoMapper;
using Tenders.Core.DTOs;
using Tenders.Core.Entities;
using Tenders.Core.Interfaces;

namespace Tenders.Core.Services
{
    class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;

        public CitizenService(ICitizenRepository citizenRepository, IMapper mapper)
        {
            _citizenRepository = citizenRepository;
            _mapper = mapper;
        }

        public void Add(CitizenRequestDto citizenRequestDto)
        {
            var citizen = _mapper.Map<Citizen>(citizenRequestDto);
            _citizenRepository.Add(citizen);
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}