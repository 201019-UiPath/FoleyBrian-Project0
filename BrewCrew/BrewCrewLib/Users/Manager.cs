using System.Collections.Generic;
using System;
namespace BrewCrewLib.Users
{
    public struct Manager
    {
        public string FName {get; set;}
        public string LName {get; set;}
        public string Id {get; set;}
        public string BreweryID {get;set;}
        public string Email {get; set;}
        public string Password {get; set;}

        // "breweryManagerfName", "breweryManagerlName", "email", "password"
        public void SetManager(Dictionary<string,string> dictionary)
        {
            this.Id = Guid.NewGuid().ToString();
            this.FName = dictionary["breweryManagerfName"];
            this.LName = dictionary["breweryManagerlName"];
            this.Email = dictionary["email"];
            this.Password = dictionary["password"];
            this.BreweryID = dictionary["breweryId"];
        }
        
    }
}