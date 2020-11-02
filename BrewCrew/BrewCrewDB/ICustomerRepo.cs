using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    public interface ICustomerRepo
    {
        //Customer Data
        void AddCustomerAsync(Customer customer);
        Customer GetUserByEmailAsync(string email);

        //Order Data
        void PlaceOrderAsync(Order order);
        void UpdateBeer(Beer beer);
         Task<List<Order>> GetAllOrdersByCustomerBreweryIdAsync(string customerId, string breweryId);

        //Beer Data
        Task<List<Beer>> GetAllBeersByBreweryIdAsync(string breweryId);
        Task<Beer> GetBeerByIdAsync(string beerId);

        //Brewery Data
        Task<List<Brewery>> GetAllBreweriesAsync();

        

       
        

    }
}