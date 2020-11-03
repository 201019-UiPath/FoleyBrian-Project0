using System.Collections.Generic;
using BrewCrewDB;
using BrewCrewDB.Models;
using Serilog;
using System;

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
            try
            {
                repo.AddBeerAsync(beer);
                Log.Information("Successfully Added Beer to Inventory");
            }catch(Exception e)
            {
                Log.Information($"Failed to add Beer to Inventory - {e.Message}");
            }
        }

        public List<Brewery> GetAllBreweries()
        {
            try {
                List<Brewery> breweries = repo.GetAllBreweriesAsync().Result;
                Log.Information("Successfully retrieved all breweries");
                return breweries;
            }catch(Exception e)
            {
                Log.Information($"Failed to retrieve all breweries - {e.Message}");
                return new List<Brewery>();
            }
            
        }

        public List<Beer> GetAllBeersByBreweryId(string breweryId)
        {
            try 
            {
                List<Beer> beers = repo.GetAllBeersByBreweryIdAsync(breweryId).Result;
                Log.Information("Successfully retrieved all beers by Brewery Id");
                return beers;
            }catch (Exception e)
            {
                Log.Information($"Failed to retrieve all beers by brewery Id - {e.Message}");
                return new List<Beer>();
            }
            
        }

        public void UpdateBeer(Beer beer)
        {
            try {
                repo.UpdateBeer(beer);
                Log.Information("Successfully Updated Beer Data");
            } catch(Exception e)
            {
                Log.Information($"Failed to update beer data - {e.Message}");
            }
            
        }

        public List<Order> GetOrderHistoryByBreweryId(string breweryId)
        {   try {
                List<Order> orders = repo.GetAllOrdersByBreweryIdAsync(breweryId).Result;
                Log.Information("Successfully retrieved all orders by brewery Id");
                return orders;
            }catch (Exception e)
            {
                Log.Information($"Failed to retrieve orders by Brewery Id - {e.Message}");
                return new List<Order>();
            }
             
        }

        public Beer GetBeerById(string beerId)
        {
            try 
            {
                Beer beer = repo.GetBeerByIdAsync(beerId).Result;
                Log.Information("Successfully retrieved Beer by beer Id");
                return beer;
            } catch (Exception e)
            {
                Log.Information($"Failed to retrieve beer by beer Id - {e.Message}");
                return new Beer();
            }
            
        }

        public Customer GetCustomerById(string customerId)
        {
            try 
            {
                Customer customer = repo.GetCustomerByIdAsync(customerId).Result;
                Log.Information("Successfully retrieved customer by customer Id");
                return customer;
            } catch(Exception e)
            {
                Log.Information($"Failed to retrieve customer By customer Id - {e.Message}");
                return new Customer();
            }
            
        }


    }
}
