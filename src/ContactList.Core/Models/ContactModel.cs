using ContactList.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Core.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }

        public ContactType Type { get; set; }

        public string Value { get; set; }

    }
}
