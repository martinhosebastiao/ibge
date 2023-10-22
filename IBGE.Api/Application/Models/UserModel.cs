using System.ComponentModel.DataAnnotations;
using IBGE.Api.Domain.Entities;

namespace IBGE.Api.Application.Models
{
    [Display(Description = "User")]
    public class UserModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4)]
        public string Password { get; set; } = null!;


        public bool IsUser { get; set; } = true;


        public User ConvertToUser() => new(Email, Password, IsUser);
    }
}

