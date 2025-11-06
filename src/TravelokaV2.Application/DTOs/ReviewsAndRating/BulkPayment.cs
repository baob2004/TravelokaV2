using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.ReviewsAndRating
{
    public class BulkPayment
    {
        public class BulkPaymentRecordCreateRequest
        {
            /// <summary>Nếu true thì bỏ qua item lỗi; nếu false thì fail-fast</summary>
            public bool SkipInvalid { get; set; } = true;

            /// <summary>CreatedAt mặc định cho mọi item (nếu item không set)</summary>
            public DateTime? DefaultCreatedAtUtc { get; set; }

            public List<BulkPaymentRecordCreateItem> Items { get; set; } = new();
        }

        public class BulkPaymentRecordCreateItem
        {
            /// <summary>User sở hữu payment record (bắt buộc)</summary>
            public string UserId { get; set; } = default!;

            public Guid? RoomId { get; set; }
            public Guid? PaymentMethodId { get; set; }
            public TravelokaV2.Domain.Enums.PaymentStatus? Status { get; set; }

            /// <summary>Nếu null → dùng DefaultCreatedAtUtc hoặc UtcNow</summary>
            public DateTime? CreatedAtUtc { get; set; }
        }

        public class BulkPaymentRecordCreateResponse
        {
            public int Total { get; set; }
            public int Succeeded { get; set; }
            public int Failed { get; set; }
            public List<BulkPaymentRecordCreateItemResult> Results { get; set; } = new();
        }

        public class BulkPaymentRecordCreateItemResult
        {
            public string Status { get; set; } = default!; // success | failed
            public Guid? PaymentRecordId { get; set; }
            public string? UserId { get; set; }
            public Guid? RoomId { get; set; }
            public Guid? PaymentMethodId { get; set; }
            public string? Error { get; set; }

            public static BulkPaymentRecordCreateItemResult Success(Guid id, string userId, Guid? roomId, Guid? pmId)
                => new() { Status = "success", PaymentRecordId = id, UserId = userId, RoomId = roomId, PaymentMethodId = pmId };

            public static BulkPaymentRecordCreateItemResult Fail(string userId, Guid? roomId, Guid? pmId, string error)
                => new() { Status = "failed", UserId = userId, RoomId = roomId, PaymentMethodId = pmId, Error = error };
        }
    }
}