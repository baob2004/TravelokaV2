namespace TravelokaV2.Domain.Entities
{
    public class Accom_Facility
    {
        public Guid Id { get; set; }
        public Guid AccomId { get; set; }
        public Guid FacilityId { get; set; }
        public Accommodation? Accommodation { get; set; }
        public Facility? Facility { get; set; }
    }
}