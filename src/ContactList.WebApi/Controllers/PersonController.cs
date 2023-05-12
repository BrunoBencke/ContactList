using ContactList.Core.Application;
using ContactList.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonAppService _service;

        public PersonController(PersonAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonModel person, CancellationToken cancellationToken) 
        {
            await _service.AddAsync(person, cancellationToken);
            return Ok(person);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] Guid id, PersonModel personRequest)
        {
            await _service.Update(id, personRequest);
            return Ok(personRequest);

        }

        /*[HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
        {
            var person = await _dbContext.Persons.FindAsync(id);

            if (person != null)
            {
                _dbContext.Remove(person);
                await _dbContext.SaveChangesAsync();
                return Ok(person);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _service.);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPerson([FromRoute] Guid id)
        {
            var person = await _dbContext.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }*/
    }
}