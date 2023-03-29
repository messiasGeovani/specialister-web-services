using Domain.Shared.Models;

namespace Domain.Entities
{
    public class PersonEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; }
    }
}
