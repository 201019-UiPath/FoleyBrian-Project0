using BrewCrewDB;
using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            repo.AddManagerAsync(manager);
        }

        public void AddBrewery(Brewery brewery)
        {
            repo.AddBreweryAsync(brewery);
        }

        public List<Manager> GetAllManagers()
        {
            Task<List<Manager>> managerTask = repo.GetAllManagersAsync();
            return managerTask.Result;
        }
    }
}