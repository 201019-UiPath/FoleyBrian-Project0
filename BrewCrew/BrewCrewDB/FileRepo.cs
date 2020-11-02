// using System.Text.Json;
// using System.IO;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using System;

// namespace BrewCrewDB
// {
//     /// <summary>
//     /// Repository using files
//     /// </summary>
//     public class FileRepo<T>: IRepository<T>
//     {
//         /// <summary>
//         /// Adds location data to DB/file
//         /// </summary>
//         /// <param name="location"></param>
//         public async void AddDataToDBAsync(List<T> data, string path) 
//         {
//             using(FileStream fs = File.Create(path)){
//                 await JsonSerializer.SerializeAsync(fs, data);
//                 Console.WriteLine($"Data is being written to file at {path}");
//             }
//         }

//         /// <summary>
//         /// Gets all data from file
//         /// </summary>
//         /// <returns></returns>
//         public async Task<List<T>> GetAllDataFromTableAsync(string path) 
//         {
            
//             List<T> allTableData;
//             using(FileStream fs = File.OpenRead(path))
//             {
//                 allTableData = (await JsonSerializer.DeserializeAsync<List<T>>(fs));
//             }
           
//             return allTableData;
//         }
//     }
// }