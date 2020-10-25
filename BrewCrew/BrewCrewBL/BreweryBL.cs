using BrewCrewDB;
using BrewCrewLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewBL
{
    public class BreweryBL
    {
         string filepathBreweries = "/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/BrewCrewDB/BreweryDataPlace/Breweries.txt";
        IRepository<Brewery> repo = new FileRepo<Brewery>();
         public void AddBrewery(Brewery brewery) 
         {
             List<Brewery> breweries;
             try {
                 breweries = GetAllBreweries();
             } catch (AggregateException e) {
                 Console.WriteLine($"Error: {e}");
                 breweries = new List<Brewery>();
             }
             
             breweries.Add(brewery);
             repo.AddDataToDBAsync(breweries, filepathBreweries);
         }

         public List<Brewery> GetAllBreweries()
        {
            Task<List<Brewery>> getBreweries = repo.GetAllDataFromTableAsync(filepathBreweries);
            return getBreweries.Result;
        }
    }
}