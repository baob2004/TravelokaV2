using System.ComponentModel.DataAnnotations.Schema;
using TravelokaV2.Domain.Abstractions;

namespace TravelokaV2.Domain.Entities
{
    public class Room : ISoftDelete
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? Breakfast { get; set; }
        public int? NumberOfBeds { get; set; }
        public Guid? BedTypeId { get; set; }
        public Guid? CancelPolicyId { get; set; }
        public bool? Available { get; set; }
        public Guid? CategoryId { get; set; }
        public float? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
        public string? UpdateBy { get; set; }
        public RoomCategory? RoomCategory { get; set; }
        public CancelPolicy? CancelPolicy { get; set; }
        public BedType? BedType { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
    }
}