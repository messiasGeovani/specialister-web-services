using Domain.Shared.Models;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
