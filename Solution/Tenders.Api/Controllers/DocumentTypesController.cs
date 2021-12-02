using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tenders.Core.DTOs;
using Tenders.Core.Entities;
using Tenders.Core.Interfaces;
using Tenders.Infrastructure.Data.Persistence;
using Tenders.Infrastructure.Data.Repositories;

namespace Tenders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private IUnitOfWorkFactory _uowFactory;
        private TenderDbContext _context;
        private readonly IRepository<CitizenDocumentType> _repository;
        private readonly IMapper _mapper;


        public DocumentTypesController(TenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _uowFactory = new EntityFrameworkUnitOfWorkFactory(context);
            _repository = new EntityFrameworkRepository<CitizenDocumentType>(context);
        }

        [HttpGet]
        public async Task<ActionResult<CitizenDocumentTypeDto>> Get()
        {
            var types = await _repository.All().ToListAsync();
            return Ok(_mapper.Map<CitizenDocumentTypeDto>(types));

        }
    }
}