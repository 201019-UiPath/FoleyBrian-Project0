using System;
using BrewCrewLib;

namespace CustomerUI.Menu
{
    public class CustomerOrderConfirm: IMenuCustomer
    {
        Beer Beer {get;set;}
        public CustomerOrderConfirm(Beer beer)
        {
            this.Beer = beer;
        }

        public void Start() 
        {
            Console.WriteLine("Confirm Beer");
            
            Console.WriteLine($"{Beer.Name} {Beer.ABV} {Beer.IBU} {Beer.Type}");
        }
    }
}