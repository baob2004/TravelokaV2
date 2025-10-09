namespace TravelokaV2.Application.DTOs.Policy
{
    public class PolicyDto
    {
        public Guid AccomId { get; set; }
        public string? Instruction { get; set; }
        public string? RequiredDocs { get; set; }
        public TimeOnly? CheckIn { get; set; }
        public TimeOnly? CheckOut { get; set; }
        public string? Breakfast { get; set; }
        public string? Smoking { get; set; }
        public string? Pets { get; set; }
        public string? Additional { get; set; }
    }
}