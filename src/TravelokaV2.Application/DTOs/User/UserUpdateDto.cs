namespace TravelokaV2.Application.DTOs.User
{
    public class UserUpdateDto
    {
        public string FullName { get; set; } = string.Empty!;
        public DateOnly? BirthDate { get; set; }
        public bool? Sex { get; set; }
    }
}
