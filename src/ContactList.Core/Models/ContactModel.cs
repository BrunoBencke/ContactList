using System.ComponentModel.DataAnnotations;

namespace ContactList.Core.Models
{
    public class ContactModel
    {
        [Required]
        public Guid PersonId { get; set; }

        [Required]
        public string ContactType { get; set; }

        [Required]
        public string ContactValue { get; set; }
    }
}
