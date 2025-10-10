using TravelokaV2.Domain.Abstractions;

namespace TravelokaV2.Domain.Entities
{
    public class Policy
    {
        public Guid AccomId { get; set; }
        public string? Intruction { get; set; }
        public string? RequireDocs { get; set; }
        public TimeOnly? CheckIn { get; set; }
        public TimeOnly? CheckOut { get; set; }
        public string? Breakfast { get; set; }
        public string? Smoking { get; set; }
        public string? Pets { get; set; }
        public string? Addtional { get; set; }
        public Accommodation Accommodation { get; set; } = default!;
    }
}