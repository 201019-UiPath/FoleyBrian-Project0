using BrewCrewDB;
using BrewCrewLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewBL
{
    public class BrewCrewBL<T>
    {
        string filepath;
        public BrewCrewBL(string type) {
            switch (type) 
            {
                case "manager":
                    this.filepath = "/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/BrewCrewDB/ManagersDataPlace/Managers.txt";
                    break;
                case "location":
                    this.filepath = "/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/BrewCrewDB/LocationsDataPlace/Locations.txt";
                    break;
                case "brewery":
                    this.filepath  = "/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/BrewCrewDB/BreweryDataPlace/Breweries.txt";
                    break;
                default:
                    Console.WriteLine("Unknown type");
                    break;
            }
        }
        
        IRepository<T> repo = new FileRepo<T>();
         public void AddData(T data) 
         {
             List<T> listData;
             try {
                 listData = GetAllListData();
             } catch (AggregateException e) {
                 Console.WriteLine($"Error: {e}");
                 listData = new List<T>();
             }
             
             listData.Add(data);
             repo.AddDataToDBAsync(listData, filepath);
         }

         public List<T> GetAllListData()
        {
            Task<List<T>> getListData = repo.GetAllDataFromTableAsync(filepath);
            return getListData.Result;
        }
    }
}