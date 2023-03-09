using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<UserDTO>? Users { get; set; }
    }
}
