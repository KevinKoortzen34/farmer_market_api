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
        private readonly List<Farmer> farmers = new List<Farmer> { 
            new (1, "Kobus", "kobus@example.com", "123-456-7890", "Location 1", "Province 1", 4.5, true), 
            new (2, "Tyrique", "tyrique@example.com", "098-765-4321", "Location 2", "Province 2", 4.0, true), 
            new (3, "Zandre", "zandre@example.com", "555-555-5555", "Location 3", "Province 3", 4.8, true)};

        [HttpGet]
        public List<Farmer> GetListOfFarmers()
        {
            return farmers;
        }

        [HttpPost]
        public List<Farmer> CreateFarmer([FromBody] Farmer farmer)
        {
            farmers.Add(farmer);
            return farmers;
        }

        [HttpDelete]
        public List<Farmer> Delete([FromQuery] int farmerId)
        {
            var farmer = farmers.FirstOrDefault(f => f.getFarmerId() == farmerId);
            if (farmer != null)
            {
                farmers.Remove(farmer);
                return farmers;
            } else
            {
                return farmers;
            }
        }

        [HttpPut]
        public Farmer UpdateFarmers([FromBody] Farmer updatedFarmer)
        {
            var farmer = farmers.FirstOrDefault(f => f.getFarmerId() == updatedFarmer.getFarmerId());
            if(farmer != null)
            {
                farmer = updatedFarmer;
                return farmer;
            }
            else
            {
                return null;
            }
        }
    }
}