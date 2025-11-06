using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.PaymentRecord;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;
using TravelokaV2.Domain.Enums;
using static TravelokaV2.Application.DTOs.ReviewsAndRating.BulkPayment;

namespace TravelokaV2.Application.Services
{
    public class PaymentRecordService : IPaymentRecordService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IPaymentRecordRepository _paymentRecordRepo;
        public PaymentRecordService(IUnitOfWork uow, IMapper mapper, IPaymentRecordRepository paymentRecordRepo)
        {
            _uow = uow;
            _mapper = mapper;
            _paymentRecordRepo = paymentRecordRepo;
        }

        public async Task<IEnumerable<PaymentRecordDto>> GetAllAsync(CancellationToken ct)
        {
            var entities = await _uow.PaymentRecords.GetAllAsync(
                null,
                null,
                true,
                ct,
                x => x.Room!,
                x => x.PaymentMethod!
            );
            return _mapper.Map<IEnumerable<PaymentRecordDto>>(entities);
        }

        public async Task<PaymentRecordDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var pr = await _uow.PaymentRecords.GetByIdAsync(
                id, asNoTracking: true, ct: ct,
                q => q.Include(x => x.PaymentMethod)!,
                q => q.Include(x => x.Room)!
            ) ?? throw new KeyNotFoundException("PaymentRecord not found.");

            return _mapper.Map<PaymentRecordDto>(pr);
        }

        public async Task<Guid> CreateAsync(PaymentRecordCreateDto dto, string currentUserId, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(currentUserId)) throw new UnauthorizedAccessException("User not authenticated.");

            if (dto.RoomId.HasValue &&
                !await _uow.Rooms.AnyAsync(r => r.Id == dto.RoomId, ct))
                throw new KeyNotFoundException("Room not found.");

            if (dto.PaymentMethodId.HasValue &&
                !await _uow.PaymentMethods.AnyAsync(p => p.Id == dto.PaymentMethodId, ct))
                throw new KeyNotFoundException("Payment method not found.");

            var entity = _mapper.Map<PaymentRecord>(dto);
            entity.UserId = currentUserId;
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.PaymentRecords.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, PaymentRecordUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = await _uow.PaymentRecords.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("PaymentRecord not found.");

            if (dto.RoomId.HasValue && dto.RoomId != entity.RoomId &&
                !await _uow.Rooms.AnyAsync(r => r.Id == dto.RoomId, ct))
                throw new KeyNotFoundException("Room not found.");

            if (dto.PaymentMethodId.HasValue && dto.PaymentMethodId != entity.PaymentMethodId &&
                !await _uow.PaymentMethods.AnyAsync(p => p.Id == dto.PaymentMethodId, ct))
                throw new KeyNotFoundException("Payment method not found.");

            _mapper.Map(dto, entity);
            await _uow.SaveChangesAsync(ct);
        }


        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.PaymentRecords.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("PaymentRecord not found.");

            _uow.PaymentRecords.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<PaymentRecordDto>> GetByUserIdAsync(string userId, CancellationToken ct)
        {
            var entities = await _paymentRecordRepo.GetByUserId(userId, ct);
            if (entities is null) throw new InvalidOperationException();

            var dtos = _mapper.Map<List<PaymentRecordDto>>(entities);
            return dtos;
        }

        public async Task<BulkPaymentRecordCreateResponse> BulkCreateAsync(BulkPaymentRecordCreateRequest req, CancellationToken ct)
        {
            if (req is null || req.Items is null || req.Items.Count == 0)
                throw new ArgumentException("Items is empty.", nameof(req));

            var resp = new BulkPaymentRecordCreateResponse { Total = req.Items.Count };
            var now = DateTime.UtcNow;

            foreach (var item in req.Items)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(item.UserId))
                        throw new ArgumentException("UserId is required.");

                    if (item.RoomId.HasValue)
                    {
                        var ok = await _uow.Rooms.AnyAsync(r => r.Id == item.RoomId, ct);
                        if (!ok) throw new KeyNotFoundException("Room not found.");
                    }

                    if (item.PaymentMethodId.HasValue)
                    {
                        var ok = await _uow.PaymentMethods.AnyAsync(p => p.Id == item.PaymentMethodId, ct);
                        if (!ok) throw new KeyNotFoundException("Payment method not found.");
                    }

                    var entity = new PaymentRecord
                    {
                        Id = Guid.NewGuid(),
                        UserId = item.UserId,
                        RoomId = item.RoomId,
                        PaymentMethodId = item.PaymentMethodId,
                        Status = item.Status ?? PaymentStatus.Success, // mặc định Success (tuỳ bạn)
                        CreatedAt = item.CreatedAtUtc ?? req.DefaultCreatedAtUtc ?? now
                    };

                    await _uow.PaymentRecords.AddAsync(entity, ct);
                    // không SaveChanges mỗi vòng để giảm round-trip
                    resp.Results.Add(BulkPaymentRecordCreateItemResult.Success(entity.Id, entity.UserId!, entity.RoomId, entity.PaymentMethodId));
                    resp.Succeeded++;
                }
                catch (Exception ex)
                {
                    if (!req.SkipInvalid) throw;
                    resp.Results.Add(BulkPaymentRecordCreateItemResult.Fail(item.UserId, item.RoomId, item.PaymentMethodId, ex.Message));
                    resp.Failed++;
                }
            }

            if (resp.Succeeded > 0)
                await _uow.SaveChangesAsync(ct);

            return resp;
        }
    }
}
