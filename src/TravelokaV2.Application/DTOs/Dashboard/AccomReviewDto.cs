using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.Dashboard
{
    public sealed class ReviewPointDto
    {
        public DateOnly Period { get; set; } // mốc thời gian (ngày/tháng/năm)
        public int Count { get; set; }       // số review tại mốc
    }

    public sealed class AccomReviewDto
    {
        public Guid AccomId { get; set; }
        public string? AccomName { get; set; }
        public IReadOnlyList<ReviewPointDto> Points { get; set; } = Array.Empty<ReviewPointDto>();
        public int Total { get; set; }      // tổng review trong khoảng lọc
    }
}