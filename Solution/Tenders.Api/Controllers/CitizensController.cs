using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tenders.Core.DTOs;
using Tenders.Core.Entities;
using Tenders.Core.Interfaces;
using Tenders.Infrastructure.Data.Persistence;
using Tenders.Infrastructure.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tenders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private IUnitOfWorkFactory _uowFactory;
        private TenderDbContext _context;
        private readonly IRepository<Citizen> _repository;
        private readonly IMapper _mapper;

        public CitizensController(TenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _uowFactory = new EntityFrameworkUnitOfWorkFactory(context);
            _repository = new EntityFrameworkRepository<Citizen>(context);
        }

        // GET: api/<CitizensController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CitizensController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CitizensController>
        [HttpPost]
        public void Post([FromBody] CitizenRequestDto value)
        {
            if (ModelState.IsValid)
            {
                using IUnitOfWork uow = _uowFactory.Create();
                var map = _mapper.Map<Citizen>(value);
                _repository.Add(map);
                uow.Save();
            }
        }

        // PUT api/<CitizensController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitizensController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}