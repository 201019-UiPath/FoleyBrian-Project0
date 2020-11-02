using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    public interface IAdminRepo
    {
        void AddBreweryAsync(Brewery brewery);

         Task<List<Brewery>> GetAllBreweriesAsync();

        void AddManagerAsync(Manager manager);

         Task<List<Manager>> GetAllManagersAsync();
    }
}