using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.Dashboard
{
    public class IncomeQuery
    {
        public int? Year { get; set; }                     // ưu tiên nếu có (sẽ set from/to = cả năm đó)
        public int? Month { get; set; }
        public DateOnly? From { get; set; }                // nếu không có Year thì dùng from/to
        public DateOnly? To { get; set; }
        public TimeGranularity Granularity { get; set; } = TimeGranularity.Day;
    }
}