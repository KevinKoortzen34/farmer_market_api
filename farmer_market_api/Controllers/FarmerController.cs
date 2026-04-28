using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmer_market_api.Exceptions;
using farmer_market_api.Models;
using farmer_market_api.repositories;
using Microsoft.AspNetCore.Mvc;

namespace farmer_market_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmerController : ControllerBase
    {

        private FarmerRepository farmerRepository = new FarmerRepository();

        [HttpGet]
        public IActionResult GetListOfFarmers()
        {
            return Ok(farmerRepository.GetAll());
        }

        [HttpPost]
        public IActionResult CreateFarmer([FromBody] Farmer farmer)
        {
            var createdFarmer = farmerRepository.Add(farmer);
            return Created($"api/farmer/{createdFarmer.FarmerId}", createdFarmer);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int farmerId)
        {
            var farmer = farmerRepository.GetByID(farmerId);
            if (farmer == null)
            {
                return NotFound($"Farmer with ID {farmerId} not found.");
            }

            var deleted = farmerRepository.Delete(farmer);
            if (!deleted)
            {
                return NotFound($"Farmer with ID {farmerId} could not be deleted.");
            }

            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateFarmer([FromBody] Farmer updatedFarmer)
        {
            var updatedFarmerResult = farmerRepository.Update(updatedFarmer);
            if (updatedFarmerResult == null)
            {
                return NotFound($"Farmer with ID {updatedFarmer.FarmerId} not found.");
            }

            return Ok(updatedFarmerResult);
        }
    }
}