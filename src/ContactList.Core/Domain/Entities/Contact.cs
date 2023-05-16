using ContactList.Core.Domain.Enums;

namespace ContactList.Core.Domain.Entities
{
    public class Contact
    {
        public Contact(Guid id, Guid personId, int sequence, ContactType type, string value)
        {
            Id = id;
            PersonId = personId;
            Sequence = sequence;
            Type = type;
            Value = value;
        }

        public Contact(Guid id, Guid personId, ContactType type, string value)
        {
            Id = id;
            PersonId = personId;
            Type = type;
            Value = value;
        }

        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public int? Sequence { get; set; }

        public ContactType Type { get; set; }

        public string Value { get; set; }

    }
}
