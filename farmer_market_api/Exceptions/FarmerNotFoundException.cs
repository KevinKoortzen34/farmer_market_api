using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmer_market_api.Exceptions
{
    public class FarmerNotFoundException : Exception
    {
        public FarmerNotFoundException(){}
        public FarmerNotFoundException(int farmerId) : base($"Farmer with ID {farmerId} not found.")
        {
        }
        public FarmerNotFoundException(string Email) : base($"Farmer with Email {Email} not found.")
        {
        }
    }
}