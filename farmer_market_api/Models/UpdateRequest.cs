using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmer_market_api.Models
{
    public class UpdateRequest
    {
        public required string OldName { get; set; }
        public required string NewName { get; set; }
    }
}