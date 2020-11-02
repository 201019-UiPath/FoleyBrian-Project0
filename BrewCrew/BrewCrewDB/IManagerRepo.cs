using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    public interface IManagerRepo
    {
        void AddBeerAsync(Beer beer);
        Task<List<Brewery>> GetAllBreweriesManagerAsync();

        Task<List<Beer>> GetAllBeersByBreweryIdAsync(string breweryId);

        void UpdateBeer(Beer beer);

        Task<Beer> GetBeerByIdAsync(string beerId);

        Task<List<Order>> GetAllOrdersByBreweryIdAsync(string breweryId);

        Task<Customer> GetCustomerByIdAsync(string customerId);

    }
}