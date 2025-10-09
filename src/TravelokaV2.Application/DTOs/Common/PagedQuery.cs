namespace TravelokaV2.Application.DTOs.Common
{
    public class PagedQuery
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public bool Desc { get; set; } = true;
    }
}