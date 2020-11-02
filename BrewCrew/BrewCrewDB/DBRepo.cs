using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB
{
    public class DBRepo: IAdminRepo, IManagerRepo, ICustomerRepo
    {
        public BrewCrewContext context;
        public DBRepo(BrewCrewContext context)
        {
            this.context = context;
        }
        public void AddManagerAsync(Manager manager)
        {
            context.Managers.AddAsync(manager);
            context.SaveChangesAsync();
        }

        public Task<List<Manager>> GetAllManagersAsync()
        {
            return context.Managers.Select(x => x).ToListAsync();
        }

        public void AddBreweryAsync(Brewery brewery)
        {
            context.Breweries.AddAsync(brewery);
            context.SaveChangesAsync();
        }

        public Task<List<Brewery>> GetAllBreweriesAsync()
        {
            return context.Breweries.Select(x => x).ToListAsync();
        }

        public void AddBeerAsync(Beer beer)
        {
            context.Beers.AddAsync(beer);
            context.SaveChanges();
        }

        public Task<List<Brewery>> GetAllBreweriesManagerAsync()
        {
            return context.Breweries.Select(x => x).ToListAsync();
        }

        public Task<List<Beer>> GetAllBeersByBreweryIdAsync(string breweryId)
        {
            return context.Beers.Where(x => x.BreweryID == breweryId).ToListAsync();
        }

        public void UpdateBeer(Beer beer)
        {
            context.Beers.Update(beer);
            context.SaveChanges();
        }

        public Task<Beer> GetBeerByIdAsync(string beerId)
        {
            return context.Beers.Where(x => x.ID == beerId).FirstAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(string customerId)
        {
            return context.Customers.Where(x => x.ID == customerId).FirstAsync();
        }

        public void AddCustomerAsync(Customer customer)
        {
            context.Customers.AddAsync(customer);
            context.SaveChanges();
        }

        public Customer GetUserByEmailAsync(string email)
        {
            return context.Customers.Where(x => x.Email == email).FirstOrDefault();
        }

        public void PlaceOrderAsync(Order order)
        {
            context.Orders.AddAsync(order);
            context.SaveChanges();
        }

        public Task<List<Order>> GetAllOrdersByBreweryIdAsync(string breweryId)
        {
            //return context.Orders.Select(x => x).Include("Orders").ToListAsync();
            return context.Orders.Where(x => x.BreweryId == breweryId).ToListAsync();
        }

        public Task<List<Order>> GetAllOrdersByCustomerBreweryIdAsync(string customerId, string breweryId)
        {
            //return context.Orders.Select(x => x).Include("Orders").ToListAsync();
            return context.Orders.Where(x => x.CustomerID == customerId).Where(y => y.BreweryId == breweryId).ToListAsync();
        }
    }
}