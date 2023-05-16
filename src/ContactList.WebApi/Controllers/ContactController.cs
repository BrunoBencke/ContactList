using ContactList.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactAppService _service;

        public ContactController(ContactAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContactsByPersonId(Guid id)
        {
            try
            {
                var contacts = await _service.GetContactsByPersonId(id);

                if (contacts == null)
                {
                    return NotFound();
                }

                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
