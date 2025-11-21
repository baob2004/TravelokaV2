using Microsoft.AspNetCore.Identity;

namespace TravelokaV2.Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        public string FullName { get; set; } = string.Empty!;
        public DateOnly? BirthDate { get; set; }
        public bool? Sex { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
    }
}