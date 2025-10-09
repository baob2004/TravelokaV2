namespace TravelokaV2.Domain.Entities
{
    public class Room_Facility
    {
        public Guid Id { get; set; }
        public Guid RoomCategoryId { get; set; }
        public Guid FacilityId { get; set; }
        public RoomCategory? RoomCategory { get; set; }
        public Facility? Facility { get; set; }
    }
}