namespace ContactList.Core.Domain.Entities
{
    public class Person
    {
        private string id;
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
        public string Name { get; set; }
        public string? LastName { get; set; }
    }
}
