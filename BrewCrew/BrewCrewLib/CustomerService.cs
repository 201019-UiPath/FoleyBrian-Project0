using BrewCrewDB;
using BrewCrewDB.Models;
using System.Collections.Generic;
using Serilog;
using System;

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
            try 
            {
                repo.AddCustomerAsync(customer);
                Log.Information("Successfully Added Customer");
            }catch (Exception e)
            {
                Log.Information($"Failed to add customer - {e.Message}");
            }
            
        }

        public void PlaceOrder(Order order)
        {
            try {
                repo.PlaceOrderAsync(order);
                Log.Information("Successfully Placed Order");
            }catch (Exception e)
            {
                Log.Information($"Failed to place order - {e.Message}");
            }
            
        }
        
        public Customer GetUserByEmail(string email)
        {
            try {
                Customer customer = repo.GetUserByEmailAsync(email);
                Log.Information("Successfully Retrieved Customer by Email");
                return customer;
            }catch(Exception e)
            {
                Log.Information($"Failed to retrieve customer by email - {e.Message}");
                return new Customer();
            }
            
        }

        public List<Brewery> GetAllBreweries()
        {
            try 
            {
                List<Brewery> breweries = repo.GetAllBreweriesAsync().Result;
                Log.Information("Successfully Retrieved All Breweries");
                return breweries;
            }catch (Exception e)
            {
                Log.Information($"Failed to retrieve all breweries - {e.Message}");
                return new List<Brewery>();
            }
            
        }

        public List<Beer> GetAllBeersByBreweryId(string breweryId)
        {
            try {
                List<Beer> beers = repo.GetAllBeersByBreweryIdAsync(breweryId).Result;
                Log.Information("Successfully Retrieved All Beers By Brewery Id");
                return beers;
            } catch (Exception e)
            {
                Log.Information($"Failed to retrieve all beers by brewery Id - {e.Message}");
                return new List<Beer>();
            }
            
        }

        public List<Order> GetAllOrdersByCustomerBreweryId(string customerId, string breweryId)
        {
            try 
            {
                List<Order> orders = repo.GetAllOrdersByCustomerBreweryIdAsync(customerId, breweryId).Result;
                Log.Information("Successfully Retrieved All Orders by Customer and Brewery Id");
                return orders;
            }catch (Exception e)
            {
                Log.Information($"Failed to retrieve all orders by Customer and Brewery Id - {e.Message}");
                return new List<Order>();
            }
            
        }

        public Beer GetBeerById(string beerId)
        {
            try 
            {
                Beer beer = repo.GetBeerByIdAsync(beerId).Result;
                Log.Information("Successfully Retrieved Beer by Id");
                return beer;
            }catch (Exception e)
            {
                Log.Information($"Failed to retrieve beer by beer Id - {e.Message}");
                return new Beer();
            }
            
        }

        public void UpdateBeer(Beer beer)
        {
            try 
            {
                repo.UpdateBeer(beer);
                Log.Information("Successfully Updated Beer Data");
            }catch(Exception e)
            {
                Log.Information($"Failed to update beer data - {e.Message}");
            }
            
        }
    }
}