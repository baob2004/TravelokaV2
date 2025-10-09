using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        protected readonly AppDbContext _context;

        private readonly IGenericRepository<Accommodation> _accommodationRepo;
        private readonly IGenericRepository<AccomType> _accomTypeRepo;
        private readonly IGenericRepository<BedType> _bedTypeRepo;
        private readonly IGenericRepository<CancelPolicy> _cancelPolicyRepo;
        private readonly IGenericRepository<Facility> _facilityRepo;
        private readonly IGenericRepository<GeneralInfo> _generalInfoRepo;
        private readonly IGenericRepository<Image> _imageRepo;
        private readonly IGenericRepository<PaymentMethod> _paymentMethodRepo;
        private readonly IGenericRepository<PaymentRecord> _paymentRecordRepo;
        private readonly IGenericRepository<Policy> _policyRepo;
        private readonly IGenericRepository<ReviewsAndRating> _reviewsAndRatingRepo;
        private readonly IGenericRepository<Room> _roomRepo;
        private readonly IGenericRepository<RoomCategory> _roomCategoryRepo;

        // join entities
        private readonly IGenericRepository<Accom_Facility> _accomFacilityRepo;
        private readonly IGenericRepository<Accom_Image> _accomImageRepo;
        private readonly IGenericRepository<Accom_RR> _accomRRRepo;
        private readonly IGenericRepository<Room_Image> _roomImageRepo;
        private readonly IGenericRepository<Room_Facility> _roomFacilityRepo;

        public UnitOfWork(
            AppDbContext context,
            IGenericRepository<Accommodation> accommodationRepo,
            IGenericRepository<AccomType> accomTypeRepo,
            IGenericRepository<BedType> bedTypeRepo,
            IGenericRepository<CancelPolicy> cancelPolicyRepo,
            IGenericRepository<Facility> facilityRepo,
            IGenericRepository<GeneralInfo> generalInfoRepo,
            IGenericRepository<Image> imageRepo,
            IGenericRepository<PaymentMethod> paymentMethodRepo,
            IGenericRepository<PaymentRecord> paymentRecordRepo,
            IGenericRepository<Policy> policyRepo,
            IGenericRepository<ReviewsAndRating> reviewsAndRatingRepo,
            IGenericRepository<Room> roomRepo,
            IGenericRepository<RoomCategory> roomCategoryRepo,
            IGenericRepository<Accom_Facility> accomFacilityRepo,
            IGenericRepository<Accom_Image> accomImageRepo,
            IGenericRepository<Accom_RR> accomRRRepo,
            IGenericRepository<Room_Image> roomImageRepo,
            IGenericRepository<Room_Facility> roomFacilityRepo
        )
        {
            _context = context;

            _accommodationRepo = accommodationRepo;
            _accomTypeRepo = accomTypeRepo;
            _bedTypeRepo = bedTypeRepo;
            _cancelPolicyRepo = cancelPolicyRepo;
            _facilityRepo = facilityRepo;
            _generalInfoRepo = generalInfoRepo;
            _imageRepo = imageRepo;
            _paymentMethodRepo = paymentMethodRepo;
            _paymentRecordRepo = paymentRecordRepo;
            _policyRepo = policyRepo;
            _reviewsAndRatingRepo = reviewsAndRatingRepo;
            _roomRepo = roomRepo;
            _roomCategoryRepo = roomCategoryRepo;

            _accomFacilityRepo = accomFacilityRepo;
            _accomImageRepo = accomImageRepo;
            _accomRRRepo = accomRRRepo;
            _roomImageRepo = roomImageRepo;
            _roomFacilityRepo = roomFacilityRepo;
        }

        // Expose 17 repos (getter-only như mẫu của bạn)
        public IGenericRepository<Accommodation> Accommodations => _accommodationRepo;
        public IGenericRepository<AccomType> AccomTypes => _accomTypeRepo;
        public IGenericRepository<BedType> BedTypes => _bedTypeRepo;
        public IGenericRepository<CancelPolicy> CancelPolicies => _cancelPolicyRepo;
        public IGenericRepository<Facility> Facilities => _facilityRepo;
        public IGenericRepository<GeneralInfo> GeneralInfos => _generalInfoRepo;
        public IGenericRepository<Image> Images => _imageRepo;
        public IGenericRepository<PaymentMethod> PaymentMethods => _paymentMethodRepo;
        public IGenericRepository<PaymentRecord> PaymentRecords => _paymentRecordRepo;
        public IGenericRepository<Policy> Policies => _policyRepo;
        public IGenericRepository<ReviewsAndRating> ReviewsAndRatings => _reviewsAndRatingRepo;
        public IGenericRepository<Room> Rooms => _roomRepo;
        public IGenericRepository<RoomCategory> RoomCategories => _roomCategoryRepo;

        public IGenericRepository<Accom_Facility> AccomFacilities => _accomFacilityRepo;
        public IGenericRepository<Accom_Image> AccomImages => _accomImageRepo;
        public IGenericRepository<Accom_RR> AccomRRs => _accomRRRepo;
        public IGenericRepository<Room_Image> RoomImages => _roomImageRepo;
        public IGenericRepository<Room_Facility> RoomFacilities => _roomFacilityRepo;

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
            => await _context.SaveChangesAsync(ct);

        public ValueTask DisposeAsync() => _context.DisposeAsync();
    }
}
