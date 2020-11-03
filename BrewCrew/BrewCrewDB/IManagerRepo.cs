using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    /// <summary>
    /// Repository handling all Manager operations on the database
    /// </summary>
    public interface IManagerRepo
    {
        //Beer Data
        void AddBeerAsync(Beer beer);
        void UpdateBeer(Beer beer);
        Task<List<Beer>> GetAllBeersByBreweryIdAsync(string breweryId);
        Task<Beer> GetBeerByIdAsync(string beerId);

        //Brewery Data
        Task<List<Brewery>> GetAllBreweriesAsync();

        //Order Data
        Task<List<Order>> GetAllOrdersByBreweryIdAsync(string breweryId);

        //Customer Data
        Task<Customer> GetCustomerByIdAsync(string customerId);

    }
}