using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    /// <summary>
    /// Repository handling all Manager operations on the database
    /// </summary>
    public interface IManagerRepo
    {
        /// <summary>
        /// Beer Data
        /// </summary>

        /// <param name="Beer">Beer to add to DB</param>
        void AddBeerAsync(BeerItems beer);

        /// <param name="Beer">Beer to be updated</param>
        void UpdateBeer(Beer beer);

        /// <param name="breweryId">List of beers is returned matched on brewery Id</param>
        Task<List<BeerItems>> GetAllBeersByBreweryIdAsync(string breweryId);

        /// <param name="beerId">Single beer is returned matched on Beer Id</param>
        Beer GetBeerByIdAsync(string beerId);

        /// <summary>
        /// Brewery Data
        /// </summary>
        /// <returns>List of All Breweries in DB table returned</returns>
        Task<List<Brewery>> GetAllBreweriesAsync();

        /// <summary>
        /// Order Data
        /// </summary>
        /// <param name="breweryId">List of orders are returned matched on Brewery Id</param>
        Task<List<Order>> GetAllOrdersByBreweryIdAsync(string breweryId);

        /// <summary>
        /// Customer Data
        /// </summary>
        /// <param name="customerId">Single customer is returned matched on customer Id</param>
        User GetCustomerByIdAsync(string customerId);

    }
}