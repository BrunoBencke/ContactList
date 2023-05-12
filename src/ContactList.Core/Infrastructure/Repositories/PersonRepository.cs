using ContactList.Core.Domain.Entities;
using ContactList.Core.Domain.Interfaces;
using ContactList.Core.Infrastructure.ApiDbContext.cs;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Core.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly APIDbContext _dbContext;

        public PersonRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Person person, CancellationToken cancellationToken = default)
        {
            await _dbContext.Persons.AddAsync(person, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _dbContext.Persons.Update(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person person)
        {
            _dbContext.Remove(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Persons.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Persons.ToListAsync(cancellationToken);
        }
    }
}
