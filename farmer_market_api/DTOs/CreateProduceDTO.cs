using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;

namespace farmer_market_api.DTOs
{
    public readonly struct CreateProduceDTO
    {
        public readonly int FarmerId;
        public readonly string Production;
        public readonly Category Category;
        public readonly double PricePerKg;
        public readonly double QuantityKg;
        public readonly bool IsAvailable;
        public readonly DateTime HarvestDate;
        public readonly DateTime DateListed;
        public readonly string? Description;

        public CreateProduceDTO(int farmerId, string production, Category category, double pricePerKg, double quantityKg, bool isAvailable, DateTime harvestDate, DateTime dateListed, string? description)
        {
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
    }
}