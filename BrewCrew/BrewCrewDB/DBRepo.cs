using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB
{
    public class DBRepo: IAdminRepo, IManagerRepo, ICustomerRepo
    {
        //Class Fields
        public BrewCrewContext context;

        //Constructor
        public DBRepo(BrewCrewContext context)
        {
            this.context = context;
        }

        //Manager Data
        public void AddManagerAsync(User user)
        {
            context.Users.AddAsync(user);
            context.SaveChangesAsync();
        }

        public Task<List<User>> GetAllManagersAsync()
        {
            return context.Users.Where(x => x.Type == "Manager").ToListAsync();
        }

        //Brewery Data
        public void AddBreweryManagerAsync(ManagersJoint manager)
        {
            context.Managers.AddAsync(manager);
            context.SaveChangesAsync();
        }

        public Task<List<Brewery>> GetAllBreweriesAsync()
        {
            return context.Breweries.Select(x => x).ToListAsync();
        }


        //Beer Data
        public void AddBeerAsync(BeerItems beer)
        {
            context.BeerItems.AddAsync(beer);
            context.SaveChanges();
        }

        public Task<List<BeerItems>> GetAllBeersByBreweryIdAsync(string breweryId)
        {
            return context.BeerItems.Where(x => x.BreweryID == breweryId).Include(b => b.Beer).ToListAsync();
        }

        public void UpdateBeer(Beer beer)
        {
            context.Beers.Update(beer);
            context.SaveChanges();
        }

        public Beer GetBeerByIdAsync(string beerId)
        {
            return context.Beers.Single(x => x.ID == beerId);
        }

        //Customer Data
        public User GetCustomerByIdAsync(string customerId)
        {
            return context.Users.Single(x => x.ID == customerId);
        }

        public void AddCustomerAsync(User user)
        {
            context.Users.AddAsync(user);
            context.SaveChanges();
        }

        public User GetUserByEmailAsync(string email)
        {
            return context.Users.Single(x => x.Email == email);
        }


        //Order Data
        public void PlaceOrderAsync(Order order)
        {
            context.Orders.AddAsync(order);
            context.SaveChanges();
        }

        public Task<List<Order>> GetAllOrdersByBreweryIdAsync(string breweryId)
        {
            return context.Orders.Where(x => x.BreweryID == breweryId).ToListAsync();
        }

        public Task<List<Order>> GetAllOrdersByCustomerBreweryIdAsync(string customerId, string breweryId)
        {
            return context.Orders.Where(x => x.UserID == customerId).Where(y => y.BreweryID == breweryId).Include("LineItems").ToListAsync();
        }
    }
}