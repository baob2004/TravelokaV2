namespace TravelokaV2.Domain.Entities
{
    public class Room_Image
    {
        public Guid Id { get; set; }
        public Guid RoomCategoryId { get; set; }
        public Guid ImageId { get; set; }
        public RoomCategory? RoomCategory { get; set; }
        public Image? Image { get; set; }
    }
}