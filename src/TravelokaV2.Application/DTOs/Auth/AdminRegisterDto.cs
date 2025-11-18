using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.Auth
{
    public class AdminRegisterDto
    {
        public string Username { get; set; } = string.Empty!;
        public string Password { get; set; } = string.Empty!;
    }
}
