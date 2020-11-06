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

        public void AddBeer(BeerItems beer)
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

        public List<BeerItems> GetAllBeersByBreweryId(string breweryId)
        {
            try 
            {
                List<BeerItems> beers = repo.GetAllBeersByBreweryIdAsync(breweryId).Result;
                Log.Information("Successfully retrieved all beers by Brewery Id");
                return beers;
            }catch (Exception e)
            {
                Log.Information($"Failed to retrieve all beers by brewery Id - {e.Message}");
                return new List<BeerItems>();
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
                Beer beer = repo.GetBeerByIdAsync(beerId);
                Log.Information("Successfully retrieved Beer by beer Id");
                return beer;
            } catch (Exception e)
            {
                Log.Information($"Failed to retrieve beer by beer Id - {e.Message}");
                return new Beer();
            }
            
        }

        public User GetCustomerById(string customerId)
        {
            try 
            {
                User customer = repo.GetCustomerByIdAsync(customerId);
                Log.Information("Successfully retrieved customer by customer Id");
                return customer;
            } catch(Exception e)
            {
                Log.Information($"Failed to retrieve customer By customer Id - {e.Message}");
                return new User();
            }
            
        }


        //NEW ITEMS
        public void DeleteManagerById(string managerId)
        {
            try 
            {
                repo.DeleteManagerById(managerId);
                Log.Information($"Manager Successfully removed");
            } catch(Exception e)
            {
                Log.Information($"Unable to Delete Manager {e.Message}");
            }
            
            
        }

         public void AddManager(User manager)
        {
            try
            {
                repo.AddManagerAsync(manager);
                Log.Information("Successfully Added Manager to Inventory");
            }catch(Exception e)
            {
                Log.Information($"Failed to add Manager to Inventory - {e.Message}");
            }
        }


    }
}
