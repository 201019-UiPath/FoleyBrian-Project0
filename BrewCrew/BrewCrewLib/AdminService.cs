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
            var log = new LoggerConfiguration()
                .WriteTo.File("/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/logs.txt")
                .CreateLogger();
        }

        public void AddManager(Manager manager)
        {
            try 
            {
                repo.AddManagerAsync(manager);
            } catch(Exception e)
            {
                Log.Logger.Information($"Unable to Add Manager Async {e.Message}");
            }
            Log.Logger.Information($"Manager Successfully Added");
            
        }

        public void AddBrewery(Brewery brewery)
        {
            try
            {
                repo.AddBreweryAsync(brewery);
            } catch (Exception e)
            {
                Log.Logger.Information($"Unable to Add Brewery {e.Message}");
            }
            Log.Logger.Information($"Brewery Successfully Added");
        }

        public List<Manager> GetAllManagers()
        {
            Task<List<Manager>> managerTask;
            try 
            {
                managerTask = repo.GetAllManagersAsync();
                Log.Logger.Information($"Manager retrieval successful");
                return managerTask.Result;
            } catch (Exception e)
            {
                Log.Logger.Information($"Unable to get all managers {e.Message}");
                return null;
            }
            
        }
    }
}