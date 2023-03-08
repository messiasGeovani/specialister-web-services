using Domain.Entities;

namespace Application.DTOs
{
    public class UserDTO
    {
        public IEnumerable<User> Users { get; set; }
    }
}
