using ContactList.Core.Domain.Entities;
using ContactList.Core.Infrastructure.Repositories;
using ContactList.Core.Models;

namespace ContactList.Core.Application
{
    public class PersonAppService
    {
        private readonly PersonRepository _personRepository;

        public PersonAppService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> AddAsync(PersonModel personModel, CancellationToken cancellationToken)
        {
            var newPerson = new Person()
            {
                Id = Guid.NewGuid(),
                Name = personModel.Name,
                LastName = personModel.LastName
            };
            await _personRepository.AddAsync(newPerson, cancellationToken);
            return newPerson;
        }

        public async Task Update(Guid id, PersonModel personRequest)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person != null)
            {
                person.Name = personRequest.Name;
                person.LastName = personRequest.LastName;

                await _personRepository.UpdateAsync(person);

            }

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
