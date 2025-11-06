namespace TravelokaV2.Application.DTOs.Dashboard
{
    public sealed class IncomePointDto
    {
        public DateOnly Period { get; set; }
        public decimal Amount { get; set; }
    }

    // tổng hợp theo accommodation
    public sealed class AccomIncomeDto
    {
        public Guid AccomId { get; set; }
        public string? AccomName { get; set; }
        public IReadOnlyList<IncomePointDto> Points { get; set; } = Array.Empty<IncomePointDto>();
        public decimal Total { get; set; }
    }

    public enum TimeGranularity
    {
        Day = 0,
        Month = 1,
        Year = 2
    }
}