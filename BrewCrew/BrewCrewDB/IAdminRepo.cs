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
        void AddBreweryManagerAsync(ManagersJoint manager);

        /// <returns>List of All Breweries in DB table returned</returns>
         Task<List<Brewery>> GetAllBreweriesAsync();

        /// <summary>
        /// Manager Data
        /// </summary>
        /// <param name="manager">manager to add to DB</param>
        void AddManagerAsync(User user);

        /// <returns>List of All Managers in DB table returned</returns>
        Task<List<User>> GetAllManagersAsync();

        ///NEW ITEMS
        Brewery GetBreweryById(string breweryId);
        void DeleteBreweryById(string breweryId);
        void DeleteManagerById(string managerId);
 
    }
}