using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmer_market_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace farmer_market_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmerController : ControllerBase
    {
        private readonly List<string> farmers = new List<string> {"Kobus", "Tyrique", "Zandre"};

        [HttpGet]
        public List<string> GetListOfFarmers()
        {
            return farmers;
        }

        [HttpPost]
        public List<string> CreateFarmer([FromBody]string name)
        {
            farmers.Add(name);
            return farmers;
        }

        public List<string> Delete([FromQuery] string name)
        {
            if (farmers.Contains(name))
            {
                farmers.Remove(name);
                return farmers;
            } else
            {
                return farmers;
            }
        }

        [HttpPut]
        public List<string> UpdateFarmers([FromBody] UpdateRequest request)
        {
            if (farmers.Contains(request.OldName))
            {
                int index = farmers.IndexOf(request.OldName);
                farmers[index] = request.NewName;
                return farmers;
             } else
            {
                return farmers;
            }
        }
    }
}