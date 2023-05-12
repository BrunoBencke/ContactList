using ContactList.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Core.Infrastructure.ApiDbContext.cs
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Contact> Contacts { get; set; }

    }
}
