using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    /// <summary>
    /// Repository handling all Admin operations on the database
    /// </summary>
    public interface IAdminRepo
    {
        /// <summary>
        /// Brewery Data
        /// </summary>
        /// <param name="brewery">brewery to add to DB</param>
        void AddBreweryAsync(Brewery brewery);

        /// <returns>List of All Breweries in DB table returned</returns>
         Task<List<Brewery>> GetAllBreweriesAsync();

        /// <summary>
        /// Manager Data
        /// </summary>
        /// <param name="manager">manager to add to DB</param>
        void AddManagerAsync(Manager manager);

        /// <returns>List of All Managers in DB table returned</returns>
         Task<List<Manager>> GetAllManagersAsync();
    }
}