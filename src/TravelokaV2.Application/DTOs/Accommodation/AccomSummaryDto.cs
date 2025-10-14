using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.Accommodation
{
    public class AccomSummaryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid? AccomTypeId { get; set; }
        public string? AccomTypeName { get; set; }

        public int? Star { get; set; }
        public float? Rating { get; set; }

        public string? Address { get; set; }
        public string? Location { get; set; }

        public Guid? CoverImageId { get; set; }
        public string? GgMapsQuery { get; set; }
        public string? Ll { get; set; }
        public decimal Price { get; set; }

    }
}