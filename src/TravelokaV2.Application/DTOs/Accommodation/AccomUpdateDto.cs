using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.Accommodation
{
    public class AccomUpdateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Guid? AccomTypeId { get; set; }

        public string? GgMapsQuery { get; set; }
        public string? Ll { get; set; }

        public int? Star { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
    }
}