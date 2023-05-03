using Domain.Shared.Models;

namespace Domain.Entities
{
    public class MessageEntity : BaseEntity
    {
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
