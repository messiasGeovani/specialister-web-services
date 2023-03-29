using System.ComponentModel.DataAnnotations;

namespace Application.Modules.Person.DTOs
{
    public class PersonDTO
    {
        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(100, ErrorMessage = "The field {0} must have length between {2} and {1} characters.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(100, ErrorMessage = "The field {0} must have length between {2} and {1} characters.", MinimumLength = 2)]
        public string LastName { get; set; }

        public string? Document { get; set; }
    }
}
