using Application.Modules.Profile.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Application.Modules.Message.DTOs
{
    public class MessageDTO
    {
        [Key]
        public Guid Id { get; set; }

        public ProfileDTO Author { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(300, ErrorMessage = "The field {0} must have length between {2} and {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }
    }
}
