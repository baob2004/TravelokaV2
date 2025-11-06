using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.Dashboard
{
    public class ReviewQuery
    {
        public int? Year { get; set; }                 // nếu có -> lấy full năm
        public DateOnly? From { get; set; }            // nếu không có Year -> dùng from/to
        public DateOnly? To { get; set; }
        public TimeGranularity Granularity { get; set; } = TimeGranularity.Day;
    }
}