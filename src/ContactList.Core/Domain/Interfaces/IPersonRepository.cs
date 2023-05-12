using ContactList.Core.Domain.Entities;

namespace ContactList.Core.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task AddAsync(Person person, CancellationToken cancellationToken = default);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
        Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
