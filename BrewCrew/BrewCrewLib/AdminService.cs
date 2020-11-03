using BrewCrewDB;
using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using System;

namespace BrewCrewLib
{
    public class AdminService
    {
        private IAdminRepo repo;
        public AdminService(IAdminRepo repo)
        {
            this.repo = repo;
        }

        public void AddManager(Manager manager)
        {
            try 
            {
                repo.AddManagerAsync(manager);
            } catch(Exception e)
            {
                Log.Information($"Unable to Add Manager Async {e.Message}");
            }
            Log.Information($"Manager Successfully Added");
            
        }

        public void AddBrewery(Brewery brewery)
        {
            try
            {
                repo.AddBreweryAsync(brewery);
            } catch (Exception e)
            {
                Log.Information($"Unable to Add Brewery {e.Message}");
            }
            Log.Information($"Brewery Successfully Added");
        }

        public List<Manager> GetAllManagers()
        {
            Task<List<Manager>> managerTask;
            try 
            {
                managerTask = repo.GetAllManagersAsync();
                Log.Information($"Manager retrieval successful");
                return managerTask.Result;
            } catch (Exception e)
            {
                Log.Information($"Unable to get all managers {e.Message}");
                return new List<Manager>();
            }
            
        }
    }
}