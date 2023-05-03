using Domain.Shared.Models;

namespace Domain.Entities
{
    public class DiscussionEntity : BaseEntity
    {
        public Guid IssueId { get; set; }

        public List<MessageEntity> Messages { get; set; }
    }
}
