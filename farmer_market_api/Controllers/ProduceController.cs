using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using farmer_market_api.DTOs;
using farmer_market_api.Exceptions;
using farmer_market_api.Models;
using farmer_market_api.repositories;
using Microsoft.AspNetCore.Mvc;

namespace farmer_market_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduceController : ControllerBase
    {
        public ProduceRepository produceRepository = new ProduceRepository();

        [HttpGet]
        public IActionResult GetProduceListings()
        {
            return Ok(produceRepository.GetAllProduceListings());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduceListingById(int id)
        {   
            try
            {
                return Ok(produceRepository.GetProduceListingById(id)); 
            }
            catch (ListingNotFoundException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/summary")]
        public IActionResult GetProduceListingSummary(int id)
        {
            var produce = produceRepository.GetProduceListingById(id);
            if (produce == null)
            {
                return NotFound($"Produce listing with ID {id} not found.");
            }
            else
            {
                return Ok(produce.GetFormattedSummary());
            }
        }

        [HttpPost]
        public IActionResult CreateProduceListing([FromBody] CreateProduceDTO newListing)
        {
            try
            {
                var produce = new ProduceListing
                {
                    FarmerId = newListing.FarmerId,
                    Production = newListing.Production,
                    Category = newListing.Category,
                    PricePerKg = newListing.PricePerKg,
                    QuantityKg = newListing.QuantityKg,
                    IsAvailable = newListing.IsAvailable,
                    HarvestDate = newListing.HarvestDate,
                    DateListed = newListing.DateListed,
                    Description = newListing.Description
                };

                produceRepository.AddProduceListing(produce);
                return CreatedAtAction(nameof(GetProduceListingById), new { id = produce.ListingId }, produce);
            }
            catch (InvalidProduceFormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("available")]
        public IActionResult GetProduceListingByQty()
        {
            return Ok(produceRepository.GetAvailable());
        }

        [HttpGet("category/{category}")]
        public IActionResult GetProduceListingByCategory([FromRoute]Category category)
        {
            return Ok(produceRepository.GetProduceListingByCategory(category));
        }
    }
}