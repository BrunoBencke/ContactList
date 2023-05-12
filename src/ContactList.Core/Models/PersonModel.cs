using System.ComponentModel.DataAnnotations;

namespace ContactList.Core.Models
{
    public class PersonModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
