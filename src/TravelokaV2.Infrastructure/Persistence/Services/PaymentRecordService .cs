using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.PaymentRecord;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class PaymentRecordService : IPaymentRecordService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PaymentRecordService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentRecordDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _uow.PaymentRecords.Query()
                .AsNoTracking()
                .Include(x => x.PaymentMethod)
                .Include(x => x.Room)
                .OrderByDescending(x => x.Id)
                .ToListAsync(ct);

            return _mapper.Map<List<PaymentRecordDto>>(list);
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

        // Application/Services/PaymentRecordService.cs (đoạn Create/Update)
        public async Task<Guid> CreateAsync(PaymentRecordCreateDto dto, string currentUserId, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(currentUserId)) throw new UnauthorizedAccessException("User not authenticated.");

            if (dto.RoomId.HasValue &&
                !await _uow.Rooms.Query().AnyAsync(r => r.Id == dto.RoomId, ct))
                throw new KeyNotFoundException("Room not found.");

            if (dto.PaymentMethodId.HasValue &&
                !await _uow.PaymentMethods.Query().AnyAsync(p => p.Id == dto.PaymentMethodId, ct))
                throw new KeyNotFoundException("Payment method not found.");

            var entity = _mapper.Map<PaymentRecord>(dto);
            entity.UserId = currentUserId;

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
                !await _uow.Rooms.Query().AnyAsync(r => r.Id == dto.RoomId, ct))
                throw new KeyNotFoundException("Room not found.");

            if (dto.PaymentMethodId.HasValue && dto.PaymentMethodId != entity.PaymentMethodId &&
                !await _uow.PaymentMethods.Query().AnyAsync(p => p.Id == dto.PaymentMethodId, ct))
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
            var entities = await _uow.PaymentRecords.Query().Where(p => p.UserId == userId).Include(p => p.Room).Include(p => p.PaymentMethod).ToListAsync(ct);
            if (entities is null) throw new InvalidOperationException();

            var dtos = entities.Select(
                e => _mapper.Map<PaymentRecordDto>(e)
            );
            return dtos;
        }
    }
}
