using System.ComponentModel.DataAnnotations;

namespace TravelokaV2.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required, StringLength(200)]
        public string FirstName { get; set; } = string.Empty;
        [Required, StringLength(200)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(320)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}