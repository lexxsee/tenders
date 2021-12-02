using AutoMapper;
using Tenders.Core.DTOs;
using Tenders.Core.Entities;
using Tenders.Core.Interfaces;
using Tenders.Infrastructure.Data.Persistence;
using Tenders.Infrastructure.Data.Repositories;

namespace Tenders.Api.Services
{
    class CitizenService : ICitizenService
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private TenderDbContext _context;
        private readonly IRepository<Citizen> _repository;
        private readonly IMapper _mapper;
        public CitizenService(TenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _uowFactory = new EntityFrameworkUnitOfWorkFactory(context);
            _repository = new EntityFrameworkRepository<Citizen>(context);
        }

        public void Add(CitizenRequestDto citizenRequestDto)
        {
            using var uow = _uowFactory.Create();
            var map = _mapper.Map<Citizen>(citizenRequestDto);
            _repository.Add(map);
            uow.Save();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}