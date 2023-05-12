using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactList.WebApi.Controllers
{
    /*[ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactListAPIDbContext _dbContext;

        public ContactController(ContactListAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContacts([FromRoute] Guid id)
        {
            var contacts = await _dbContext.Contacts.Where(c => c.Id == id).FirstOrDefaultAsync<Contact>();

            if (contacts == null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactInputModel contact)
        {
            var newcontact = new Contact()
            {
                Id = Guid.NewGuid(),
                ContactType = contact.ContactType,
                ContactValue = contact.ContactValue
            };

            await _dbContext.Contacts.AddAsync(newcontact);
            await _dbContext.SaveChangesAsync();
            return Ok(newcontact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, ContactInputModel contactRequest)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                contact.ContactType = contactRequest.ContactType;
                contact.ContactValue = contactRequest.ContactValue;

                await _dbContext.SaveChangesAsync();

                return Ok(contact);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                _dbContext.Remove(contact);
                await _dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();
        }
    }*/
}
