using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.PaymentMethod;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PaymentMethodService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentMethodDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _uow.PaymentMethods.Query()
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync(ct);

            return _mapper.Map<List<PaymentMethodDto>>(list);
        }

        public async Task<PaymentMethodDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.PaymentMethods.GetByIdAsync(id, ct: ct)
                ?? throw new KeyNotFoundException("PaymentMethod not found.");

            return _mapper.Map<PaymentMethodDto>(entity);
        }

        public async Task<Guid> CreateAsync(PaymentMethodCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required.", nameof(dto.Name));

            var dup = await _uow.PaymentMethods.Query()
                .AnyAsync(x => x.Name == dto.Name, ct);
            if (dup) throw new InvalidOperationException("PaymentMethod already exists.");

            var entity = _mapper.Map<PaymentMethod>(dto);

            await _uow.PaymentMethods.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, PaymentMethodUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required.", nameof(dto.Name));

            var entity = await _uow.PaymentMethods.GetByIdAsync(id, asNoTracking: false, ct: ct)
                ?? throw new KeyNotFoundException("PaymentMethod not found.");

            var dup = await _uow.PaymentMethods.Query()
                .AnyAsync(x => x.Id != id && x.Name == dto.Name, ct);
            if (dup) throw new InvalidOperationException("Another PaymentMethod with same name exists.");

            _mapper.Map(dto, entity);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.PaymentMethods.GetByIdAsync(id, asNoTracking: false, ct: ct)
                ?? throw new KeyNotFoundException("PaymentMethod not found.");

            _uow.PaymentMethods.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }
    }
}
