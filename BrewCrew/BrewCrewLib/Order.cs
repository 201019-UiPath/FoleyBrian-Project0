using System.Collections.Generic;
using System;

namespace BrewCrewLib
{
    public class Order
    {
        public string ID {get; set;}
        public string BreweryID {get;set;}
        public string CustomerID {get;set;}
        public string Date {get; set;}
        public List<Beer> Beers {get; set;}

        public void SetOrder(Dictionary<string,string> dictionary)
        {   
            this.ID = dictionary["id"];
            this.BreweryID = dictionary["breweryId"];
            this.CustomerID = dictionary["customerId"];
            this.Date = DateTime.Now.ToString();

        }

        public void AddBeerToOrder(Beer beer)
        {
            Beers.Add(beer);
        }
    }

    
}