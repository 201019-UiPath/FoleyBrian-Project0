using System;
using System.Collections.Generic;

namespace BrewCrewLib
{
    public class Beer
    {
        public string ID {get; set;}
        public string BreweryID {get; set;}
        public string Name {get; set;}
        public string Type {get; set;}
        public string ABV {get; set;}
        public string IBU {get; set;}
        public string Keg {get; set;}

        //"name", "abv", "ibu" "breweryId", "type"
        public void SetBeer(Dictionary<string, string> dictionary) 
        {
            this.ID = Guid.NewGuid().ToString();
            this.BreweryID = dictionary["breweryId"];
            this.Name = dictionary["name"];
            this.Type = dictionary["type"];
            this.ABV = dictionary["abv"];
            this.IBU = dictionary["ibu"];
            this.Keg = "50";
            foreach(var val in dictionary) {
                Console.WriteLine(val.Value);
            }
        }   
    }

    
}