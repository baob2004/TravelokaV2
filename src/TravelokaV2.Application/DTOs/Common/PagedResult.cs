namespace TravelokaV2.Application.DTOs.Common
{
    public class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; set; } = Array.Empty<T>();
        public int Page { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
        public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling((double)Total / PageSize);
    }
}
