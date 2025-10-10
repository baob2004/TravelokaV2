using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelokaV2.Application.DTOs.AccomType
{
    public class AccomTypeDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public string? UpdateBy { get; set; }
    }
}