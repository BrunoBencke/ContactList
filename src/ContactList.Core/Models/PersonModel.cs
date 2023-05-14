using ContactList.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactList.Core.Models
{
    public class PersonModel
    {
        public Person person { get; set; }

        public Contact[] contacts { get; set; }
    }
}
