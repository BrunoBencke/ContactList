using ContactList.Core.Domain.Entities;
using ContactList.Core.Domain.Enums;
using ContactList.Core.Domain.Interfaces;
using ContactList.Core.Infrastructure.Repositories;
using ContactList.Core.Models;

namespace ContactList.Core.Application
{
    public class ContactAppService
    {
        private readonly ContactRepository _contactRepository;

        public ContactAppService(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> AddAsync(ContactModel contactModel, CancellationToken cancellationToken)
        {

            var newContact = new Contact(contactModel.Id, contactModel.PersonId, 0, contactModel.Type, contactModel.Value);
            await _contactRepository.AddAsync(newContact, cancellationToken);

            return newContact;
    }

        public async Task<IEnumerable<Contact>> GetContactsByPersonId(Guid id)
        {
            var contacts = await _contactRepository.GetContactsByPersonId(id);

            return contacts;
        }
    }
}
