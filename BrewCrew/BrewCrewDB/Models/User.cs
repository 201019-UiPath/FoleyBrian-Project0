using System.Collections.Generic;

namespace BrewCrewDB.Models
{
    public class User
    {
        public string ID {get; set;}
        public string FName {get; set;}
        public string LName {get; set;}
        public string Email{get; set;}
        public string Password{get; set;}
        public string Type{get;set;}
        public List<Order> Orders {get;set;}

    }
}