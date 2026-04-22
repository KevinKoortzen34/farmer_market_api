using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmer_market_api.Models;

namespace farmer_market_api.repositories
{
    public class FarmerRepository
    {
        private readonly List<Farmer> farmers = new List<Farmer> { 
            new (1, "Kobus", "kobus@example.com", "123-456-7890", "Location 1", "Province 1", 4.5, true), 
            new (2, "Tyrique", "tyrique@example.com", "098-765-4321", "Location 2", "Province 2", 4.0, true), 
            new (3, "Zandre", "zandre@example.com", "555-555-5555", "Location 3", "Province 3", 4.8, true)};


        public List<Farmer> GetAllFarmers()
        {
            return farmers;
        }

        public Farmer CreateFarmer(Farmer farmer)
        {
            int newId = farmers.Max(f => f.FarmerId) + 1;
            farmer.FarmerId = newId;
            farmers.Add(farmer);
            return farmer;
        }

        public bool DeleteFarmer(int farmerId)
        {
            var farmer = farmers.FirstOrDefault(f => f.getFarmerId() == farmerId);
            if (farmer != null)
            {
                farmers.Remove(farmer);
                return true;
            }
            return false;
        }

        public Farmer GetFarmerById(int id)
        {
            for (int i = 0; i < farmers.Count; i++)
            {
                if (farmers[i].FarmerId == id)
                {
                    return farmers[i];
                }
            }
            return null;
        }

        public Farmer UpdateFarmer(Farmer updatedFarmer)
        {
            var farmer = farmers.FirstOrDefault(f => f.getFarmerId() == updatedFarmer.getFarmerId());
            if(farmer != null)
            {
                farmer = updatedFarmer;
                return farmer;
            }
            return null;
        }
    }
}