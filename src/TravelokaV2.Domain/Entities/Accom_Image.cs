namespace TravelokaV2.Domain.Entities
{
    public class Accom_Image
    {
        public Guid Id { get; set; }
        public Guid AccomId { get; set; }
        public Guid ImageId { get; set; }
        public Accommodation? Accommodation { get; set; }
        public Image? Image { get; set; }
    }
}