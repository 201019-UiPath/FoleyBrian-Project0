using System.Collections.Generic;

namespace BrewCrewDB.Models
{
    public class BeerItems
    {
        public string ID {get;set;}
        public string BreweryID {get;set;}
        public Brewery brewery {get;set;}
        public string BeerID {get;set;}
        public Beer Beer {get;set;}
        public string Keg {get;set;}
        
    }
}