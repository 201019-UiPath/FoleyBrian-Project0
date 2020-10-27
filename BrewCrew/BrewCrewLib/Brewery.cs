using System.Collections.Generic;
using System;

namespace BrewCrewLib
{
    
    public struct Brewery
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string State {get; set;}
        public string City {get; set;}
        public string Address {get; set;}
        public string Zip {get;set;}

        // "breweryName"
        public void SetBrewery(Dictionary<string,string> dictionary) {
            this.ID = dictionary["id"];
            this.Name = dictionary["breweryName"];
            this.State = dictionary["state"];
            this.City = dictionary["city"];
            this.Address = dictionary["address"];
            this.Zip = dictionary["zip"];
        }
    }

    
}