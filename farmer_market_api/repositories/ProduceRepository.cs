using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using farmer_market_api.Exceptions;
using farmer_market_api.Models;

namespace farmer_market_api.repositories
{
    public class ProduceRepository
    {
        private List<ProduceListing> produceListings = new List<ProduceListing>()
        {
            new (1, 1, "Tomatoes", Category.Vegetables, 2.5, 100, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5), "Freshly harvested tomatoes."),
            new (2, 2, "Apples", Category.Fruits, 3.0, 50, true, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-15), "Crisp and sweet apples."),
            new (3, 3, "Carrots", Category.Vegetables, 1.8, 250, false, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2), "Organic carrots from our farm.")
        };

        public ProduceListing AddProduceListing(ProduceListing produce)
        {

            if(string.IsNullOrEmpty(produce.Production))
            {
                throw new InvalidProduceFormatException("Production name cannot be empty.");
            }
            else if(produce.PricePerKg <= 0)
            {
                throw new InvalidProduceFormatException("Price per kg must be greater than zero.");
            }
            else if(produce.QuantityKg <= 0)
            {
                throw new InvalidProduceFormatException("Quantity cannot be negative or zero.");
            }     
            
            int newId = produceListings.Max(p => p.ListingId) + 1;
            produce.ListingId = newId;
            produceListings.Add(produce);
            return produce;
        }

        public List<ProduceListing> GetAllProduceListings()
        {
            return produceListings;
        }

        public ProduceListing GetProduceListingById(int id)
        {
            for (int i = 0; i < produceListings.Count; i++)
            {
                if (produceListings[i].ListingId == id)
                {
                    return produceListings[i];
                }
            }
            throw new ListingNotFoundException($"Produce listing with ID {id} not found.");
        }
 
        public ProduceListing GetProduceListingByCategory(Category category)
        {
            return produceListings.FirstOrDefault(p => p.Category == category);
        }

        public List<ProduceListing> GetAvailable()
        {
            return produceListings.Where(p => p.IsAvailable).ToList();
        }
    }
}