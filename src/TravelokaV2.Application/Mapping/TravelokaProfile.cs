using AutoMapper;
using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.AccomType;
using TravelokaV2.Application.DTOs.Assignments.Accommodation;
using TravelokaV2.Application.DTOs.Assignments.RoomCategory;
using TravelokaV2.Application.DTOs.BedType;
using TravelokaV2.Application.DTOs.CancelPolicy;
using TravelokaV2.Application.DTOs.Facility;
using TravelokaV2.Application.DTOs.GeneralInfo;
using TravelokaV2.Application.DTOs.Image;
using TravelokaV2.Application.DTOs.PaymentMethod;
using TravelokaV2.Application.DTOs.PaymentRecord;
using TravelokaV2.Application.DTOs.Policy;
using TravelokaV2.Application.DTOs.ReviewsAndRating;
using TravelokaV2.Application.DTOs.Room;
using TravelokaV2.Application.DTOs.RoomCategory;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Mapping
{
    public class TravelokaProfile : Profile
    {
        public TravelokaProfile()
        {
            // ========== Accommodation ==========
            CreateMap<Accommodation, AccomSummaryDto>();
            CreateMap<Accommodation, AccomDetailDto>();
            CreateMap<AccomCreateDto, Accommodation>();
            CreateMap<AccomUpdateDto, Accommodation>();

            // ========== GeneralInfo ==========
            CreateMap<GeneralInfo, GeneralInfoDto>();
            CreateMap<GeneralInfoCreateDto, GeneralInfo>();
            CreateMap<GeneralInfoUpdateDto, GeneralInfo>();

            // ========== Policy ==========
            CreateMap<Policy, PolicyDto>();
            CreateMap<PolicyCreateDto, Policy>();
            CreateMap<PolicyUpdateDto, Policy>();

            // ========== Facility ==========
            CreateMap<Facility, FacilityDto>();
            CreateMap<FacilityCreateDto, Facility>();
            CreateMap<FacilityUpdateDto, Facility>();

            // ========== Image ==========
            CreateMap<Image, ImageDto>();
            CreateMap<ImageCreateDto, Image>();
            CreateMap<ImageUpdateDto, Image>();

            // ========== RoomCategory ==========
            CreateMap<RoomCategory, RoomCategoryDto>();
            CreateMap<RoomCategoryCreateDto, RoomCategory>();
            CreateMap<RoomCategoryUpdateDto, RoomCategory>();

            // ========== Room ==========
            CreateMap<Room, RoomSummaryDto>();
            CreateMap<Room, RoomDetailDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();

            // ========== ReviewsAndRating ==========
            CreateMap<ReviewsAndRating, ReviewDto>();
            CreateMap<ReviewCreateDto, ReviewsAndRating>();
            CreateMap<ReviewUpdateDto, ReviewsAndRating>();

            // ========== BedType ==========
            CreateMap<BedType, BedTypeDto>();
            CreateMap<BedTypeCreateDto, BedType>();
            CreateMap<BedTypeUpdateDto, BedType>();

            // ========== CancelPolicy ==========
            CreateMap<CancelPolicy, CancelPolicyDto>();
            CreateMap<CancelPolicyCreateDto, CancelPolicy>();
            CreateMap<CancelPolicyUpdateDto, CancelPolicy>();

            // ========== PaymentMethod ==========
            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<PaymentMethodCreateDto, PaymentMethod>();
            CreateMap<PaymentMethodUpdateDto, PaymentMethod>();

            // ========== PaymentRecord ==========
            CreateMap<PaymentRecord, PaymentRecordDto>();
            CreateMap<PaymentRecordCreateDto, PaymentRecord>();

            // ========== AccomType (thêm DTO đơn giản) ==========
            CreateMap<AccomType, AccomTypeDto>();
            CreateMap<AccomTypeCreateDto, AccomType>();
            CreateMap<AccomTypeUpdateDto, AccomType>();

            // ========== Join Entities (assign DTOs đơn giản) ==========
            CreateMap<AccomImageCreateDto, Accom_Image>();
            CreateMap<AccomReviewCreateDto, Accom_RR>();
            CreateMap<AccomFacilityCreateDto, Accom_Facility>();

            CreateMap<RoomImageCreateDto, Room_Image>();
            CreateMap<RoomFacilityCreateDto, Room_Facility>();
        }
    }
}