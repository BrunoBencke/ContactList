using ContactList.Core.Domain.Enums;

namespace ContactList.Core.Domain.Entities
{
    public class Contact
    {
        private string id;
        private string id_person;

        public Guid Id
        {
            get
            {
                return Guid.Parse(id);
            }
            set
            {
                if (value != null && value != Guid.Empty)
                {
                    id = value.ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid GUID value");
                }
            }
        }

        public Guid PersonId
        {
            get
            {
                return Guid.Parse(id_person);
            }
            set
            {
                if (value != null && value != Guid.Empty)
                {
                    id_person = value.ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid GUID value");
                }
            }
        }

        public ContactType Type { get; set; }

        public string Value { get; set; }
    }
}
