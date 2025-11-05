using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Interfaces
{
    public interface IPaymentRecordRepository : IGenericRepository<PaymentRecord>
    {
        Task<IEnumerable<PaymentRecord>> GetByUserId(string userId, CancellationToken ct);
    }
}