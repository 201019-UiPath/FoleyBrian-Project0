using BrewCrewDB;
using BrewCrewLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewBL
{
    public class LocationBL
    {
         string filepathLocations = "/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/BrewCrewDB/LocationsDataPlace/Locations.txt";
        IRepository<Location> repo = new FileRepo<Location>();
         public void AddLocation(Location location) 
         {
             List<Location> locations;
             try {
                 locations = GetAllLocations();
             } catch (AggregateException e) {
                 Console.WriteLine($"Error: {e}");
                 locations = new List<Location>();
             }
             
             locations.Add(location);
             repo.AddDataToDBAsync(locations, filepathLocations);
         }

         public List<Location> GetAllLocations()
        {
            Task<List<Location>> getLocations = repo.GetAllDataFromTableAsync(filepathLocations);
            return getLocations.Result;
        }
    }
}