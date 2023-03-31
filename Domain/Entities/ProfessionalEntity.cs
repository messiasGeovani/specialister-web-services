using Domain.Shared.Models;

namespace Domain.Entities
{
    public class ProfessionalEntity : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public Guid AddressId { get; set; }
        public AddressEntity CompanyAddress { get; set; }
    }
}
