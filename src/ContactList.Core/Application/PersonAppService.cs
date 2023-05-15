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

        public async Task<Person> AddAsync(PersonModel person, CancellationToken cancellationToken)
        {

            var newPerson = new Person()
            {
                Id = person.person.Id,
                Name = person.person.Name,
                LastName = person.person.LastName
            };
            await _personRepository.AddAsync(newPerson, cancellationToken);

            foreach (var contactPayload in person.contacts)
            {
                var contact = new Contact
                {
                    Id = contactPayload.Id,
                    PersonId = newPerson.Id,
                    Type = (ContactType)contactPayload.Type,
                    Value = contactPayload.Value
                };

                await _contactRepository.AddAsync(contact);
            }

            return newPerson;
        }

        public async Task Update(Guid id, PersonModel personRequest)
        {
            var person = await _personRepository.GetByIdAsync(id);

            /*if (person != null)
            {
                person.Name = personRequest.Name;
                person.LastName = personRequest.LastName;

                await _personRepository.UpdateAsync(person);

            }*/

        }

        public async Task Delete(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person != null)
            {
                await _personRepository.DeleteAsync(person);
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
