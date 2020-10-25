using BrewCrewLib.Users;
using BrewCrewLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewDB
{
    public interface IRepository<T>
    {
         void AddDataToDBAsync(List<T> data, string path);

         Task<List<T>> GetAllDataFromTableAsync(string path);
    }
}