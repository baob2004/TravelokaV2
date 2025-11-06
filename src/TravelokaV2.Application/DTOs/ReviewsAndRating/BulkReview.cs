using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.ReviewsAndRating
{
    public class BulkReview
    {
        public class BulkReviewCreateRequest
        {
            /// <summary>Nếu true, bỏ qua khi user đã có review cho accom này (theo rule của bạn)</summary>
            public bool SkipExisting { get; set; } = true;

            /// <summary>Nếu có, áp dụng CreatedAt cho tất cả item (nếu từng item không set)</summary>
            public DateTime? DefaultCreatedAtUtc { get; set; }

            [Required]
            public List<BulkReviewCreateItem> Items { get; set; } = new();
        }

        public class BulkReviewCreateItem
        {
            /// <summary>Ưu tiên UserId; nếu null sẽ thử Username/Email</summary>
            public string? UserId { get; set; }

            public string? UserNameOrEmail { get; set; }

            [Range(1, 5)]
            public float Rating { get; set; }

            [MaxLength(2000)]
            public string? Comment { get; set; }

            /// <summary>Tuỳ chọn: nếu null sẽ dùng DefaultCreatedAtUtc hoặc UtcNow</summary>
            public DateTime? CreatedAtUtc { get; set; }
        }

        public class BulkReviewCreateResponse
        {
            public Guid AccommodationId { get; set; }
            public int Total { get; set; }
            public int Succeeded { get; set; }
            public int Skipped { get; set; }
            public int Failed { get; set; }
            public List<BulkReviewCreateItemResult> Results { get; set; } = new();
        }

        public class BulkReviewCreateItemResult
        {
            public string Status { get; set; } = default!; // success | skipped | failed
            public string? UserId { get; set; }
            public string? ResolvedUserName { get; set; }
            public Guid? ReviewId { get; set; }
            public string? Message { get; set; }
            public List<string>? Errors { get; set; }

            public static BulkReviewCreateItemResult Success(string userId, string? userName, Guid reviewId)
                => new() { Status = "success", UserId = userId, ResolvedUserName = userName, ReviewId = reviewId };

            public static BulkReviewCreateItemResult Skip(string? reason, string? userId = null, string? userName = null)
                => new() { Status = "skipped", Message = reason, UserId = userId, ResolvedUserName = userName };

            public static BulkReviewCreateItemResult Fail(IEnumerable<string> errors, string? userId = null, string? userName = null)
                => new() { Status = "failed", Errors = errors.ToList(), UserId = userId, ResolvedUserName = userName };
        }
    }
}