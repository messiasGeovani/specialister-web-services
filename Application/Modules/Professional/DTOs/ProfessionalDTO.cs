using Application.Modules.Address.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Application.Modules.Professional.DTOs
{
    public class ProfessionalDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(100, ErrorMessage = "The field {0} must have length between {2} and {1} characters.", MinimumLength = 2)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(100, ErrorMessage = "The field {0} must have length between {2} and {1} characters.", MinimumLength = 2)]
        public string Position { get; set; }

        public AddressDTO? CompanyAddress { get; set; }
    }
}
