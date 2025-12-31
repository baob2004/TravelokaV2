namespace TravelokaV2.Application.DTOs.User
{
    public class UserPersonalInfoDto
    {
        public string FullName { get; set; } = string.Empty!;
        public DateOnly? BirthDate { get; set; }
        public bool? Sex { get; set; }
        public string Email { get; set; } = null!;
    }
}
