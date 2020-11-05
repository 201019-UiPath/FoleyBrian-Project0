using System;
using System.Collections.Generic;

namespace BrewCrewDB.Models
{
    public class Beer
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string Type {get; set;}
        public string ABV {get; set;}
        public string IBU {get; set;}
        public string Price {get; set;}
        // public string ID {get; set;}
        // public string BreweryID {get; set;}
        // public string Name {get; set;}
        // public string Type {get; set;}
        // public string ABV {get; set;}
        // public string IBU {get; set;}
        // public string Keg {get; set;}
        // public Brewery Brewery {get;set;}
        // // "name", "abv", "ibu" "breweryId", "type"
        // public List<Order> Orders {get;set;}
        // public void SetBeer(Dictionary<string, string> dictionary) 
        // {
        //     this.ID = Guid.NewGuid().ToString();
        //     this.BreweryID = dictionary["breweryId"];
        //     this.Name = dictionary["name"];
        //     this.Type = dictionary["type"];
        //     this.ABV = dictionary["abv"];
        //     this.IBU = dictionary["ibu"];
        //     this.Keg = "50";
        // }   
    }  
}