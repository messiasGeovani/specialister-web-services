using Application.Modules.Profile.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Application.Modules.Connections.DTOs
{
    public class ConnectionDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        public ProfileDTO Profile { get; set; }
    }
}
