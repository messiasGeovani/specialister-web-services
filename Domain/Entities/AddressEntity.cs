using Domain.Shared.Models;

namespace Domain.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public PersonEntity Person { get; set; }
        public ProfessionalEntity Professional { get; set; }
    }
}
