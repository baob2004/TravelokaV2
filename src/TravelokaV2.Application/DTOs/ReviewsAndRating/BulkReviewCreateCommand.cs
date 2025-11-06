using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static TravelokaV2.Application.DTOs.ReviewsAndRating.BulkReview;

namespace TravelokaV2.Application.DTOs.ReviewsAndRating
{
    public class BulkReviewCreateCommand
    {
        [Required]
        public Guid AccomId { get; set; }

        // các trường y hệt BulkReviewCreateRequest
        public bool SkipExisting { get; set; } = true;
        public DateTime? DefaultCreatedAtUtc { get; set; }

        [Required]
        public List<BulkReviewCreateItem> Items { get; set; } = new();
    }
}