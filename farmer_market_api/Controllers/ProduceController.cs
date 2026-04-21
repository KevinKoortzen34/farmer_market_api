using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using farmer_market_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace farmer_market_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduceController : ControllerBase
    {
        private List<ProduceListing> produceListings = new List<ProduceListing>()
        {
            new (1, 1, "Tomatoes", Category.Vegetables, 2.5, 100, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5), "Freshly harvested tomatoes."),
            new (2, 2, "Apples", Category.Fruits, 3.0, 50, true, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-15), "Crisp and sweet apples."),
            new (3, 3, "Carrots", Category.Vegetables, 1.8, 250, false, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2), "Organic carrots from our farm.")
        };

        [HttpGet]
        public IActionResult GetProduceListings()
        {
            return Ok(produceListings);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduceListingById(int id)
        {
            var produce = produceListings.FirstOrDefault(p => p.ListingId == id);
            if (produce == null)
            {
                return NotFound($"Produce listing with ID {id} not found.");
            }
            else
            {
                return Ok(produce);
            }
        }

        [HttpGet("{id}/summary")]
        public IActionResult GetProduceListingSummary(int id)
        {
            var produce = produceListings.FirstOrDefault(p => p.ListingId == id);
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
        public IActionResult CreateProduceListing([FromBody] ProduceListing newListing)
        {
            produceListings.Add(newListing);
            return Created($"http://localhost:5079/api/produce/{newListing.ListingId}", produceListings);
        }

        [HttpGet("available")]
        public IActionResult GetProduceListingByQty()
        {
            var produceWithStock = produceListings.Where(p => p.QuantityKg > 0 && p.IsAvailable).ToList();
            if (produceWithStock.Count == 0)
            {
                return NotFound("No available produce listings found.");
            }
            else
            {
                return Ok(produceWithStock);
            }
        }

        [HttpGet("catagory/{category}")]
        public IActionResult GetProduceListingByCatagory([FromRoute]Category category)
        {
            return Ok(produceListings.Where(p => p.Category == category).ToList());
        }
    }
}