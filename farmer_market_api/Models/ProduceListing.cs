using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmer_market_api.Models
{
    public class ProduceListing
    {
        public int ListingId { get; set; }
        public int FarmerId { get; set; }
        public string Production { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double PricePerKg { get; set; } = 0.0;
        public double QuantityKg { get; set; } = 0.0;
        public bool IsAvailable { get; set; } = true;
        public DateTime HarvestDate { get; set; } = DateTime.Now;
        public DateTime DateListed { get; set; } = DateTime.Now;
        public string? Description { get; set; }

        public ProduceListing(int listingId, int farmerId, string production, string category, double pricePerKg, double quantityKg, bool isAvailable, DateTime harvestDate, DateTime dateListed, string? description)
        {
            ListingId = listingId;
            FarmerId = farmerId;
            Production = production;
            Category = category;
            PricePerKg = pricePerKg;
            QuantityKg = quantityKg;
            IsAvailable = isAvailable;
            HarvestDate = harvestDate;
            DateListed = dateListed;
            Description = description;
        }

        public ProduceListing()
        {
            
        }

        public string GetFormattedSummary()
        {
            return $"""
            Produce: {Production}, 
            Price:{PricePerKg:F2}, 
            Quantity: {QuantityKg}kg, 
            Category: {Category},
            Description: {Description ?? "No description provided."}
            """;
        }

        public double CalculateRevenue()
        {
            return PricePerKg * QuantityKg;
        }
    }
}