using System.Collections.Generic;
using System;

namespace BrewCrewLib
{
    
    public class Brewery
    {
        public string Id {get; set;}
        public string name {get; set;}

        // "breweryName"
        public void SetBrewery(Dictionary<string,string> dictionary) {
            this.Id = Guid.NewGuid().ToString();
            this.name = dictionary["breweryName"];
        }
    }

    
}