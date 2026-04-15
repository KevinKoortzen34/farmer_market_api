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
    public class ProduceController : ControllerBase
    {
        private List<ProduceListing> produceListings = new List<ProduceListing>()
        {
            new (1, 1, "Tomatoes", "Vegetables", 2.5, 100, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5), "Freshly harvested tomatoes."),
            new (2, 2, "Apples", "Fruits", 3.0, 50, true, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-15), "Crisp and sweet apples."),
            new (3, 3, "Carrots", "Vegetables", 1.8, 200, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2), "Organic carrots from our farm.")
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
                return Ok(produce.GetFormattedSummary());
            }
        }
    }
}