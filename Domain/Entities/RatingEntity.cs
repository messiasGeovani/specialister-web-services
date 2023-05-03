using Domain.Shared.Models;

namespace Domain.Entities
{
    public class RatingEntity : BaseEntity
    {
        public string Grade { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ReceiverID { get; set; }
        public ProfileEntity Receiver { get; set; }
        public Guid AuthorID { get; set; }
        public ProfileEntity Author { get; set; }
    }
}
