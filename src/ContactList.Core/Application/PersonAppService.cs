using ContactList.Core.Domain.Entities;
using ContactList.Core.Domain.Interfaces;
using ContactList.Core.Models;

namespace ContactList.Core.Application
{
    public class PersonAppService
    {
        private readonly IPersonRepository _personRepository;

        public PersonAppService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task AddAsync(PersonModel personModel, CancellationToken cancellationToken)
        {
            var newPerson = new Person()
            {
                Id = Guid.NewGuid(),
                Name = personModel.Name,
                LastName = personModel.LastName
            };
            await _personRepository.AddAsync(newPerson, cancellationToken);
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

        /*public void Delete(Guid id)
        {
            _personRepository.Remove(id);
        }

        public PersonModel GetById(Guid id)
        {
            var person = _personRepository.GetById(id);

            return _mapper.Map<PersonModel>(person);
        }

        public IEnumerable<PersonModel> GetAll()
        {
            var people = _personRepository.GetAll();

            return _mapper.Map<IEnumerable<PersonModel>>(people);
        }*/
    }
}
