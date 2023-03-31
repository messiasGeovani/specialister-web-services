using Application.Modules.User.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Application.Modules.Profile.DTOs
{
    public class ProfileDTO
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(500, ErrorMessage = "The maximum of {0} characters was reached!")]
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public bool? Completed { get; set; }
        public UserDTO? User { get; set; }
    }
}
