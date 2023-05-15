using ContactList.Core.Domain.Entities;
using ContactList.Core.Domain.Interfaces;
using ContactList.Core.Infrastructure.ApiDbContext.cs;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Core.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly APIDbContext _dbContext;

        public ContactRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Contact contact, CancellationToken cancellationToken = default)
        {
            await _dbContext.Contacts.AddAsync(contact, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact contact)
        {
            _dbContext.Remove(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Contacts.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Contacts.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Contact>> GetContactsByPersonId(Guid id)
        {
            var contacts = await _dbContext.Contacts.Where(c => c.PersonId == id).ToListAsync();

            return contacts;
        }
    }
}
