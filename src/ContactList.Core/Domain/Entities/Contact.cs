using ContactList.Core.Domain.Enums;

namespace ContactList.Core.Domain.Entities
{
    public class Contact
    {
        public Contact(Guid personId, ContactType type, string value)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
            Type = type;
            Value = value;
        }

        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public ContactType Type { get; set; }

        public int Sequence { get; set; }

        public string Value { get; set; }
    }
}
