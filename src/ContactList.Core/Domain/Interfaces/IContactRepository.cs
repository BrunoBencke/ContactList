using ContactList.Core.Domain.Entities;

namespace ContactList.Core.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task AddAsync(Contact contact, CancellationToken cancellationToken = default);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(Contact contact);
        Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
