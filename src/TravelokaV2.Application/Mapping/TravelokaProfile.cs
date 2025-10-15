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
            CreateMap<Accommodation, AccomSummaryDto>()
            .ForMember(d => d.Price, o => o.MapFrom(s =>
                s.RoomCategories
                .SelectMany(rc => rc.Rooms)
                .OrderBy(r => r.Price)
                .Select(r => (decimal?)r.Price)
                .FirstOrDefault()
            ));
            CreateMap<Accommodation, AccomDetailDto>()
            .ForMember(d => d.AccomTypeName,
                    o => o.MapFrom(s => s.AccomType != null ? s.AccomType.Type : null))

            .ForMember(d => d.Facilities,
                o => o.MapFrom(s => s.Accom_Facilities
                    .Where(af => af.Facility != null)
                    .Select(af => af.Facility!)))

            .ForMember(d => d.Images,
                o => o.MapFrom(s => s.Accom_Images
                    .Where(ai => ai.Image != null)
                    .Select(ai => ai.Image!)))

            .ForMember(d => d.RoomCategories,
                o => o.MapFrom(s => s.RoomCategories))

            .ForMember(d => d.Reviews, o => o.MapFrom(s =>
                s.Accom_RRs
                .Where(ar => ar.ReviewsAndRating != null)
                .Select(ar => ar.ReviewsAndRating!))
            );

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
            CreateMap<RoomCategory, RoomCategoryDto>()
                .ForMember(d => d.Images, o => o.MapFrom(s =>
                    s.Room_Images
                     .Where(ri => ri.Image != null)
                     .Select(ri => ri.Image!)))
                .ForMember(d => d.Facilities, o => o.MapFrom(s =>
                    s.Room_Facilities
                     .Where(rf => rf.Facility != null)
                     .Select(rf => rf.Facility!)))
                .ForMember(d => d.Rooms, o => o.MapFrom(s => s.Rooms));
            CreateMap<RoomCategoryCreateDto, RoomCategory>();
            CreateMap<RoomCategoryUpdateDto, RoomCategory>();

            // ========== Room ==========
            CreateMap<Room, RoomDetailDto>()
                .ForMember(d => d.BedTypeName, o => o.MapFrom(s => s.BedType != null ? s.BedType.Type : null))
                .ForMember(d => d.CancelPolicyName, o => o.MapFrom(s => s.CancelPolicy != null ? s.CancelPolicy.Type : null))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.RoomCategory != null ? s.RoomCategory.Name : null))
                .ForMember(d => d.UpdateBy, o => o.MapFrom(s => s.UpdateBy != null ? s.UpdateBy : null));

            CreateMap<Room, RoomSummaryDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.RoomCategory != null ? s.RoomCategory.Name : null))
                .ForMember(d => d.BedTypeName, o => o.MapFrom(s => s.BedType != null ? s.BedType.Type : null));

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
            CreateMap<PaymentRecord, PaymentRecordDto>()
                .ForMember(d => d.PaymentMethodName, o => o.MapFrom(s => s.PaymentMethod != null ? s.PaymentMethod.Name : null))
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room != null ? s.Room.Name : null))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Room != null ? s.Room.Price : null));

            CreateMap<PaymentRecordCreateDto, PaymentRecord>();
            CreateMap<PaymentRecordUpdateDto, PaymentRecord>();


            // ========== AccomType (thêm DTO đơn giản) ==========
            CreateMap<AccomType, AccomTypeDto>();
            CreateMap<AccomTypeCreateDto, AccomType>();
            CreateMap<AccomTypeUpdateDto, AccomType>();

            // ========== Join Entities (assign DTOs đơn giản) ==========
            CreateMap<AccomImageAssignDto, Accom_Image>();
            CreateMap<AccomReviewCreateDto, Accom_RR>();
            CreateMap<AccomFacilityCreateDto, Accom_Facility>();

            CreateMap<RoomImageCreateDto, Room_Image>();
            CreateMap<RoomFacilityCreateDto, Room_Facility>();
        }
    }
}