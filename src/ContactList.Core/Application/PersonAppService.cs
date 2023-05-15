using ContactList.Core.Domain.Entities;
using ContactList.Core.Domain.Enums;
using ContactList.Core.Infrastructure.Repositories;
using ContactList.Core.Models;

namespace ContactList.Core.Application
{
    public class PersonAppService
    {
        private readonly PersonRepository _personRepository;
        private readonly ContactRepository _contactRepository;

        public PersonAppService(PersonRepository personRepository, ContactRepository contactRepository)
        {
            _personRepository = personRepository;
            _contactRepository = contactRepository;
        }

        public async Task<Person> AddAsync(PersonModel personModel, CancellationToken cancellationToken)
        {

            var newPerson = new Person()
            {
                Id = personModel.person.Id,
                Name = personModel.person.Name,
                LastName = personModel.person.LastName
            };
            await _personRepository.AddAsync(newPerson, cancellationToken);

            foreach (var contactPayload in personModel.contacts)
            {
                var sequence = 0;

                var contact = new Contact(contactPayload.Id, newPerson.Id, sequence++, (ContactType)contactPayload.Type, contactPayload.Value);

                await _contactRepository.AddAsync(contact);
            }

            return newPerson;
        }

        public async Task Update(Guid id, PersonModel personModel)
        {
            var updatePerson = await _personRepository.GetByIdAsync(id);

            if (updatePerson != null)
            {
                updatePerson.Name = personModel.person.Name;
                updatePerson.LastName = personModel.person.LastName;

                await _personRepository.UpdateAsync(updatePerson);
            }

            var sequence = 0;

            foreach (Contact contact in personModel.contacts)
            {
                var person = await _contactRepository.GetByIdAsync(contact.Id);
                if (person != null)
                {
                    person.Sequence = sequence++;
                    await _contactRepository.UpdateAsync(person);
                }
                else
                {
                    contact.Sequence = sequence++;
                    await _contactRepository.AddAsync(contact);
                }

            }

        }

        public async Task Delete(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person != null)
            {
                await _personRepository.DeleteAsync(person);
            }

            var contacts = await _contactRepository.GetContactsByPersonId(id);

            foreach (Contact contact in contacts)
            {
                await _contactRepository.DeleteAsync(contact);
            }
        }

        public async Task<Person> GetById(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var people = await _personRepository.GetAllAsync();

            return people;
        }
    }
}
