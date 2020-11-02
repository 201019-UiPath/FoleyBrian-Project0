using System;
using BrewCrewDB.Models;

namespace CustomerUI.Menu
{
    public class CustomerOrderConfirm: IMenuCustomer
    {
        public Beer Beer {get;set;}
        public void Start() 
        {
            if(int.Parse(Beer.Keg) < 1)
            {
                Console.WriteLine($"Sorry We are out of {Beer.Name}");
            } else 
            {
                CustomerCartMenu.Beers.Add(Beer);
                Console.WriteLine($"{Beer.Name} Has Been Added to your cart");
                Console.WriteLine($"ABV: {Beer.ABV}%");
                Console.WriteLine($"IBUs: {Beer.IBU}");
                Console.WriteLine($"Type: {Beer.Type}");
            }
            Console.WriteLine("Press any key to return");
            Console.Read();
            
            
        }
    }
}