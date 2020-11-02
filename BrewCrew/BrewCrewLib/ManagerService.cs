using System.Collections.Generic;
using BrewCrewDB;
using BrewCrewDB.Models;

namespace BrewCrewLib
{
    public class ManagerService
    {
        private IManagerRepo repo;
        public ManagerService(IManagerRepo repo)
        {
            this.repo = repo;
        }

        public void AddBeer(Beer beer)
        {
            repo.AddBeerAsync(beer);
        }

        public List<Brewery> GetAllBreweries()
        {
            return repo.GetAllBreweriesAsync().Result;
        }

        public List<Beer> GetAllBeersByBreweryId(string breweryId)
        {
            return repo.GetAllBeersByBreweryIdAsync(breweryId).Result;
        }

        public void UpdateBeer(Beer beer)
        {
            repo.UpdateBeer(beer);
        }

        public List<Order> GetOrderHistoryByBreweryId(string breweryId)
        {
             return repo.GetAllOrdersByBreweryIdAsync(breweryId).Result;
        }

        public Beer GetBeerById(string beerId)
        {
            return repo.GetBeerByIdAsync(beerId).Result;
        }

        public Customer GetCustomerById(string customerId)
        {
            return repo.GetCustomerByIdAsync(customerId).Result;
        }


    }
}
