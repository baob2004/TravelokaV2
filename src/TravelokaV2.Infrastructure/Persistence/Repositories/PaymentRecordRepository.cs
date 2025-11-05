using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBooking.Infrastructure.Persistence.Repositories;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Repositories
{
    public class PaymentRecordRepository : GenericRepository<PaymentRecord>, IPaymentRecordRepository
    {
        public PaymentRecordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PaymentRecord>> GetByUserId(string userId, CancellationToken ct)
        {
            return await _context.PaymentRecords
                .AsNoTracking()
                .Where(p => p.UserId == userId)
                .Include(p => p.Room)
                .Include(p => p.PaymentMethod)
                .ToListAsync(ct);
        }
    }
}