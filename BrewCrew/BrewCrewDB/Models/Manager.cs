using System.Collections.Generic;
using System;
using BrewCrewDB.Models;

namespace BrewCrewDB.Models
{
    public class Manager: User
    {
        public string BreweryID {get;set;}
        public Brewery Brewery {get;set;}

        // "first name", "last name", "email", "password breweryId"
        public void SetManager(Dictionary<string,object> dictionary)
        {
            base.ID = (string)Guid.NewGuid().ToString();
            base.FName = (string)dictionary["first name"];
            base.LName = (string)dictionary["last name"];
            base.Email = (string)dictionary["email"];
            base.Password = (string)dictionary["password"];
            this.BreweryID = (string)dictionary["breweryId"];
        }
        
    }
}