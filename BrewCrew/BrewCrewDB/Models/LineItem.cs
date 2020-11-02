// using System;
// using System.Collections.Generic;

// namespace BrewCrewDB.Models
// {
//     public class LineItem
//     {
//         public string Id {get; set;}
//         public string OrderId {get;set;}
//         public string BeerId {get;set;}
//         public List<Beer> Beers {get;set;}
//         public void SetLineItem(Dictionary<string,object> dictionary)
//         {   
//             this.Id = Guid.NewGuid().ToString();
//             this.Beers = (List<Beer>)dictionary["beers"];
//             this.OrderId = (string)dictionary["orderId"];
//             this.BeerId = 

//         }
//     }


// }