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
        public async Task<IActionResult> AddPerson([FromBody]PersonModel person, CancellationToken cancellationToken)
        {
            try
            {
                var newPerson = await _service.AddAsync(person, cancellationToken);
                return Ok(newPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] Guid id, PersonModel personRequest)
        {
            await _service.Update(id, personRequest);
            return Ok(personRequest);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPerson([FromRoute] Guid id)
        {
            var person = await _service.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}