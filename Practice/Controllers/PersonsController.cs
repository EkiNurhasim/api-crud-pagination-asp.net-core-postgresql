using Microsoft.AspNetCore.Mvc;
using Practice.Dtos;
using Practice.Services;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonsController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            IEnumerable<PersonResponse> response = await this.personService.GetPersons();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] Guid id)
        {
            PersonResponse? response = await personService.GetPersonById(id);
            return response == null ? NotFound($"Person with id {id} is not found") : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonRequest personRequest)
        {
            await personService.CreatePerson(personRequest);
            return Created();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] Guid id, [FromBody] PersonRequest personRequest)
        {
            PersonResponse? response = await personService.UpdatePerson(id, personRequest);
            return response == null ? NotFound($"Person with id {id} is not found"): Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
        {
            bool response = await personService.DeletePerson(id);
            return response == false ? NotFound($"Person with id {id} is not found"): NoContent();
        }

        [HttpGet]
        [Route("pagination")]
        public async Task<IActionResult> PaginationPerson([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            Pageable<PersonResponse> response = await personService.PaginationPerson(page, size);
            return Ok(response);
        }
    }
}

