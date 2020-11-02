using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    public interface ICustomerRepo
    {
        void AddCustomerAsync(Customer customer);
        void PlaceOrderAsync(Order order);

        Task<List<Beer>> GetAllBeersByBreweryIdAsync(string breweryId);

        Customer GetUserByEmailAsync(string email);

        Task<List<Brewery>> GetAllBreweriesAsync();

        Task<Beer> GetBeerByIdAsync(string beerId);

        Task<List<Order>> GetAllOrdersByCustomerBreweryIdAsync(string customerId, string breweryId);
        void UpdateBeer(Beer beer);

    }
}