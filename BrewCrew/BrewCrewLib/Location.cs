using System.Collections.Generic;
using System;

namespace BrewCrewLib
{
    public struct Location
    {
        public string ID {get; set;}
        public string State {get; set;}
        public string City {get; set;}
        public string Address {get; set;}
        public string Zip {get;set;}


        //dictionary includes {"state", "city", "address", "zip"}; 
        public void SetLocation(Dictionary<string,string> dictionary) 
        {
            this.ID = Guid.NewGuid().ToString();
            this.State = dictionary["state"];
            this.City = dictionary["city"];
            this.Address = dictionary["address"];
            this.Zip = dictionary["zip"];
        }
        
    }
}