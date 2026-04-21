using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;

namespace farmer_market_api.structs
{
    public struct FarmerLocation
    {
        public string FarmName;
        public Province Province;
        public string Town;

        public FarmerLocation(string farmName, Province province, string town)
        {
            FarmName = farmName;
            Province = province;
            Town = town;
        }
    }
}