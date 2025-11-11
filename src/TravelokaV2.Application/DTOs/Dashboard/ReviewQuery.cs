using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.Dashboard
{
    public class ReviewQuery
    {
        // --- CẬP NHẬT LOGIC LỌC ---

        /// <summary>
        /// Lọc theo năm cụ thể (ví dụ: 2024).
        /// Sẽ bị bỏ qua nếu From/To được cung cấp.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Lọc theo tháng cụ thể (ví dụ: 11).
        /// PHẢI đi kèm với Year (ví dụ: Tháng 11 năm 2024).
        /// Sẽ bị bỏ qua nếu From/To được cung cấp.
        /// </summary>
        public int? Month { get; set; }

        /// <summary>
        /// Lọc theo khoảng thời gian tùy chỉnh (BẮT ĐẦU).
        /// Nếu được cung cấp, Year và Month sẽ bị BỎ QUA.
        /// </summary>
        public DateOnly? From { get; set; }

        /// <summary>
        /// Lọc theo khoảng thời gian tùy chỉnh (KẾT THÚC).
        /// Nếu được cung cấp, Year và Month sẽ bị BỎ QUA.
        /// </summary>
        public DateOnly? To { get; set; }

        /// <summary>
        /// Chia nhỏ dữ liệu theo Ngày, Tháng, hoặc Năm.
        /// </summary>
        public TimeGranularity Granularity { get; set; } = TimeGranularity.Day;
    }
}