using ContactList.Core.Domain.Enums;

namespace ContactList.Core.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public ContactType Type { get; set; }

        public string Value { get; set; }
    }
}
