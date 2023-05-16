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
        public async Task<IActionResult> AddPerson([FromBody] PersonModel person, CancellationToken cancellationToken)
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
        public async Task<IActionResult> UpdatePerson(Guid id, PersonModel personRequest)
        {
            try
            {
                await _service.Update(id, personRequest);
                return Ok(personRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPerson([FromRoute] Guid id)
        {
            try
            {
                var person = await _service.GetById(id);

                if (person == null)
                {
                    return NotFound();
                }

                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
