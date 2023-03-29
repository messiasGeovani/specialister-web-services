using System.ComponentModel.DataAnnotations;

namespace Application.Modules.Address.DTOs
{
    public class AddressDTO
    {
        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(100, ErrorMessage = "Maximum limit of {0} characters reached!")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(10, ErrorMessage = "Maximum limit of {0} characters reached!")]
        public string Number { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(10, ErrorMessage = "Maximum limit of {0} characters reached!")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(10, ErrorMessage = "Maximum limit of {0} characters reached!")]
        public string State { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(10, ErrorMessage = "Maximum limit of {0} characters reached!")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(10, ErrorMessage = "Maximum limit of {0} characters reached!")]
        public string Country { get; set; }
    }
}
