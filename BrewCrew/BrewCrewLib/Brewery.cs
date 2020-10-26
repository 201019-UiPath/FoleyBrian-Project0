using System.Collections.Generic;
using System;

namespace BrewCrewLib
{
    
    public struct Brewery
    {
        public string ID {get; set;}
        public string Name {get; set;}

        // "breweryName"
        public void SetBrewery(Dictionary<string,string> dictionary) {
            this.ID = Guid.NewGuid().ToString();
            this.Name = dictionary["breweryName"];
        }
    }

    
}