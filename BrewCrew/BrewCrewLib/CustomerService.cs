using BrewCrewDB;
using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewLib
{
    public class CustomerService
    {
        public ICustomerRepo repo;
        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public void AddCustomer(Customer customer)
        {
            repo.AddCustomerAsync(customer);
        }

        public void PlaceOrder(Order order)
        {
            repo.PlaceOrderAsync(order);
        }
        
        public Customer GetUserByEmail(string email)
        {
            return repo.GetUserByEmailAsync(email);
        }

        public List<Brewery> GetAllBreweries()
        {
            return repo.GetAllBreweriesAsync().Result;
        }

        public List<Beer> GetAllBeersByBreweryId(string breweryId)
        {
            return repo.GetAllBeersByBreweryIdAsync(breweryId).Result;
        }

        Task<List<Order>> GetAllOrdersByCustomerId(string customerId)
        {
            return repo.GetAllOrdersByCustomerIdAsync(customerId);
        }

        public Beer GetBeerById(string beerId)
        {
            return repo.GetBeerByIdAsync(beerId).Result;
        }

        public void UpdateBeer(Beer beer)
        {
            repo.UpdateBeer(beer);
        }
    }
}