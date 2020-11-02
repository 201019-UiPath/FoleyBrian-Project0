using System.Collections.Generic;

namespace BrewCrewDB.Models
{
    
    public class Brewery
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string State {get; set;}
        public string City {get; set;}
        public string Address {get; set;}
        public string Zip {get;set;}
        public List<Order> Orders {get; set;}
        public List<Beer> Beers {get;set;}
        public Manager Manager {get;set;}

        // "breweryName"
        public void SetBrewery(Dictionary<string,object> dictionary) {
            this.ID = (string)dictionary["id"];
            this.Name = (string)dictionary["name"];
            this.State = (string)dictionary["state"];
            this.City = (string)dictionary["city"];
            this.Address = (string)dictionary["address"];
            this.Zip = (string)dictionary["zip"];
        }
    }

    
}