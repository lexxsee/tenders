using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tenders.Api.Services;
using Tenders.Core.DTOs;

namespace Tenders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CitizensController : ControllerBase
    {
        private readonly ICitizenService _citizenService;

        public CitizensController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CitizenDto>>> Get()
        {
            return Ok(await _citizenService.GetAllAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<CitizenDto>>> Get([FromQuery] CitizenFilterDto filter)
        {
            return Ok(await _citizenService.FindAsync(filter));
        }

        [HttpGet("cvs")]
        [Produces("text/plain")]
        public async Task<ActionResult<string>> GetCvs()
        {
            return Ok(await _citizenService.ExportToCvsAsync());
        }


        [HttpGet("search/document/{TypeId}/{Number}")]
        public async Task<ActionResult<CitizenDto>> Get([FromRoute] CitizenDocumentFilterDto dto)
        {
            return Ok(await _citizenService.FindByDocumentAsync(dto));
        }

        [HttpPost]
        public async Task Post([FromBody] CitizenRequestDto value)
        {
            if (ModelState.IsValid)
            {
                await _citizenService.AddAsync(value);
            }
        }

        [HttpPost("cvs")]
        [Produces("text/plain")]
        public async Task PostCvs([FromBody] string value)
        {
            if (ModelState.IsValid)
            {
                await _citizenService.ImportFromCvsAsync(value);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CitizenRequestDto value)
        {
            if (ModelState.IsValid)
            {
                await _citizenService.EditAsync(id, value);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            await _citizenService.RemoveAsync(id);
        }
    }
}