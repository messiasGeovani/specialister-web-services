﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(100, ErrorMessage = "The field {0} must have length between {2} and {1} characters.", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(16, ErrorMessage = "The field {0} must have length between {2} and {1} characters.", MinimumLength = 8)]
        public string Password { get; set; }
        public string? Token { get; set; }
        public IEnumerable<User>? Users { get; set; }
    }
}
