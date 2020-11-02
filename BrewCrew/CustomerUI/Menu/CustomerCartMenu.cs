using System.Collections.Generic;
using BrewCrewDB.Models;
using BrewCrewDB;
using BrewCrewLib;
using System;

namespace CustomerUI.Menu
{
    public class CustomerCartMenu: IMenuCustomer
    {
        //STATIC VARS
        public static List<Beer> Beers = new List<Beer>();
        public static string TableNumber {get;set;}
        //END

        private string UserInput {get;set;}
        private CustomerService customerService;
        public string CustomerId {get;set;}
        public string BreweryId {get;set;}
        private readonly string[] options = {"Back", "Place Order"};
        public CustomerCartMenu(DBRepo repo)
        {
            this.customerService = new CustomerService(repo);
        }
        public void Start()
        {
           do 
           {
               Console.WriteLine("Here is a list of everything in your cart");

               foreach(var beer in CustomerCartMenu.Beers)
               {
                   Console.WriteLine($"Name: {beer.Name}");
                   Console.WriteLine($"\tABV: {beer.ABV}");
                   Console.WriteLine($"\tIBU: {beer.IBU}");
                   Console.WriteLine($"\tKeg: {beer.Type}");
                   Console.WriteLine($"\tABV: {beer.Keg}");
                   Console.WriteLine();
               }
                for(int i = 0; i < options.Length; i++)
               {
                   Console.WriteLine($"[{i}] - {options[i]}");
               }
               UserInput = Console.ReadLine();
               switch(UserInput)
               {
                    case "0":
                        break;
                        //place Order
                    case "1":
                        PlaceOrder();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

               }
           }while(!(UserInput == "0"));
        }
        private void PlaceOrder()
        {
            foreach(var beer in CustomerCartMenu.Beers)
            {
                Dictionary<string,object> orderItems = new Dictionary<string, object>();
                Order order = new Order();
                orderItems["customerId"] = CustomerId;
                orderItems["tableNumber"] = CustomerCartMenu.TableNumber;
                orderItems["breweryId"] = BreweryId;
                orderItems["orderId"] = order.ID;
                orderItems["beerId"] = beer.ID;
                order.SetOrder(orderItems);
                customerService.PlaceOrder(order);
                DecrementKeg(beer);
            }
            CustomerCartMenu.Beers.Clear();
        }

         private void DecrementKeg(Beer beer) {
            int keg = int.Parse(beer.Keg);
            keg -= 10;
            beer.Keg = keg.ToString();
            customerService.UpdateBeer(beer);
        } 
    }
}