using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    public interface IAdminRepo
    {
        //Brewery Data
        void AddBreweryAsync(Brewery brewery);

         Task<List<Brewery>> GetAllBreweriesAsync();

         //Manager Data

        void AddManagerAsync(Manager manager);

         Task<List<Manager>> GetAllManagersAsync();
    }
}