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
            return Ok(farmerRepository.GetAllFarmers());
        }

        [HttpPost]
        public IActionResult CreateFarmer([FromBody] Farmer farmer)
        {
            try
            {
                var createdFarmer = farmerRepository.CreateFarmer(farmer);
                return Created($"api/farmer/{createdFarmer.FarmerId}", createdFarmer);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
            
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int farmerId)
        {
            try
            {
                var deletedFarmer = farmerRepository.DeleteFarmer(farmerId);
                return NoContent();
            }
            catch (FarmerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateFarmer([FromBody] Farmer updatedFarmer)
        {
            try
            {
                var updatedFarmerResult = farmerRepository.UpdateFarmer(updatedFarmer);
                return Ok(updatedFarmerResult);
            }
            catch (FarmerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}