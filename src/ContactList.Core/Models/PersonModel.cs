using ContactList.Core.Domain.Entities;

namespace ContactList.Core.Models
{
    public class PersonModel
    {
        public Person person { get; set; }

        public ContactModel[] contacts { get; set; }
    }
}
