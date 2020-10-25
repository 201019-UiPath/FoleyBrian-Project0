using System;
using BrewCrewLib.Users;
using BrewCrewLib;
using BrewCrewDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewBL
{

    public class ManagerBL
    {
        const string filepathManagers = "/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/BrewCrewDB/ManagersDataPlace/Managers.txt";
        IRepository<Manager> repo = new FileRepo<Manager>();
          public void AddManager(Manager manager) 
         {
             List<Manager> managers;
             try {
                 managers = GetAllManagers();
             } catch (AggregateException e) {
                 Console.WriteLine($"Error: {e}");
                 managers = new List<Manager>();
             }
             
             managers.Add(manager);
             repo.AddDataToDBAsync(managers, filepathManagers);
         }

         public List<Manager> GetAllManagers()
        {
            Task<List<Manager>> getManagers = repo.GetAllDataFromTableAsync(filepathManagers);
            return getManagers.Result;
        }

    }
}
