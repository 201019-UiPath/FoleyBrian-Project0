using System;

namespace CustomerUI.Menu
{
    public class CustomerOrderMenu: IMenuCustomer
    {
        private string BreweryID {get;set;}
        private string BreweryName {get;set;}
        public CustomerOrderMenu(string breweryName, string breweryId) 
        {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
        }
        public void Start()
        {

        }
    }
}