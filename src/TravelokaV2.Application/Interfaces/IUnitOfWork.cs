using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<Accommodation> Accommodations { get; }
        IGenericRepository<AccomType> AccomTypes { get; }
        IGenericRepository<BedType> BedTypes { get; }
        IGenericRepository<CancelPolicy> CancelPolicies { get; }
        IGenericRepository<Facility> Facilities { get; }
        IGenericRepository<GeneralInfo> GeneralInfos { get; }
        IGenericRepository<Image> Images { get; }
        IGenericRepository<PaymentMethod> PaymentMethods { get; }
        IGenericRepository<PaymentRecord> PaymentRecords { get; }
        IGenericRepository<Policy> Policies { get; }
        IGenericRepository<ReviewsAndRating> ReviewsAndRatings { get; }
        IGenericRepository<Room> Rooms { get; }
        IGenericRepository<RoomCategory> RoomCategories { get; }
        IGenericRepository<Accom_Facility> AccomFacilities { get; }
        IGenericRepository<Accom_Image> AccomImages { get; }
        IGenericRepository<Accom_RR> AccomRRs { get; }
        IGenericRepository<Room_Image> RoomImages { get; }
        IGenericRepository<Room_Facility> RoomFacilities { get; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}