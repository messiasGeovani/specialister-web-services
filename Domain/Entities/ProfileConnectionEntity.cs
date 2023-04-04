using Domain.Shared.Models;

namespace Domain.Entities
{
    public class ProfileConnectionEntity : BaseEntity
    {
        public Guid ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
