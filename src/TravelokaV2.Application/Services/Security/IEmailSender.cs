using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelokaV2.Application.Services.Security
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subjec, string htmlMessage);
    }
}
