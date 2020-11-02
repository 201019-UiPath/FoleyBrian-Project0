using System.Collections.Generic;
using System;

namespace BrewCrewDB.Models
{
    public class Customer: User
    {
        public List<Order> Order {get;set;} 
        public void SetCustomer(Dictionary<string,object> dictionary)
        {
            base.ID = (string)Guid.NewGuid().ToString();
            base.FName = (string)dictionary["first name"];
            base.LName = (string)dictionary["last name"];
            base.Email = (string)dictionary["email"];
            base.Password = (string)dictionary["password"];
        }
    }


}