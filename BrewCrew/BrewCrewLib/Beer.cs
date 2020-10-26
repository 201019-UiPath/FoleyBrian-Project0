using System;
using System.Collections.Generic;

namespace BrewCrewLib
{
    public struct Beer
    {
        public string ID {get; set;}
        public string BreweryID {get; set;}
        public string Name {get; set;}
        public string ABU {get; set;}
        public string IBU {get; set;}
        public string Keg {get; set;}

        //"name", "abv", "ibu" "breweryId"
        public void SetBeer(Dictionary<string, string> dictionary) 
        {
            this.ID = Guid.NewGuid().ToString();
            this.BreweryID = dictionary["breweryId"];
            this.Name = dictionary["breweryId"];
            this.ABU = dictionary["breweryId"];
            this.IBU = dictionary["breweryId"];
            this.Keg = "100";
            foreach(var val in dictionary) {
                Console.WriteLine(val.Value);
            }
        }   
    }

    
}