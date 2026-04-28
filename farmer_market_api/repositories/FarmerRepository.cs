using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmer_market_api.interfaces;
using farmer_market_api.Models;

namespace farmer_market_api.repositories
{
    public class FarmerRepository : IRepository<Farmer>
    {
        private readonly List<Farmer> farmers = new List<Farmer> { 
            new (1, "Kobus", "kobus@example.com", "123-456-7890", "Location 1", "Province 1", 4.5, true), 
            new (2, "Tyrique", "tyrique@example.com", "098-765-4321", "Location 2", "Province 2", 4.0, true), 
            new (3, "Zandre", "zandre@example.com", "555-555-5555", "Location 3", "Province 3", 4.8, true)};

        public List<Farmer> GetAll()
        {
            return farmers;
        }

        public Farmer Add(Farmer farmer)
        {
            int newId = farmers.Max(f => f.FarmerId) + 1;
            farmer.FarmerId = newId;
            farmers.Add(farmer);
            return farmer;
        }

        public bool Delete(Farmer farmer)
        {
            var farmerToRemove = farmers.FirstOrDefault(f => f.FarmerId == farmer.FarmerId);
            if (farmerToRemove != null)
            {
                farmers.Remove(farmerToRemove);
                return true;
            }
            return false;
        }

        public Farmer? GetByID(int id)
        {
            return farmers.FirstOrDefault(f => f.FarmerId == id);
        }

        public Farmer? Update(Farmer updatedFarmer)
        {
            var index = farmers.FindIndex(f => f.FarmerId == updatedFarmer.FarmerId);
            if (index >= 0)
            {
                farmers[index] = updatedFarmer;
                return updatedFarmer;
            }
            return null;
        }
    }
}