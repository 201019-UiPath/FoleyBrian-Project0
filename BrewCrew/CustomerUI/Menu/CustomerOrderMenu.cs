using System;
using System.Collections.Generic;
using BrewCrewDB.Models;
using BrewCrewDB;
using BrewCrewLib;

namespace CustomerUI.Menu
{
    public class CustomerOrderMenu: IMenuCustomer
    {
        private CustomerOrderConfirm orderConfirm;
        private CustomerOrderHistoryMenu orderHistoryMenu;
        private string UserInput {get;set;}
        DBRepo repo;
        CustomerService customerService;
        private CustomerCartMenu cartMenu;
        private List<BeerItems> BeerItems {get;set;}
         private readonly string[] options = {"Back", "View Cart", "View Order History"};
        public string BreweryID {get;set;}
        public string BreweryName {get;set;}
        public string CustomerId {get;set;}

        public CustomerOrderMenu(DBRepo repo) {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.orderConfirm = new CustomerOrderConfirm();
            this.cartMenu = new CustomerCartMenu(repo);
            this.orderHistoryMenu = new CustomerOrderHistoryMenu(repo);
        }
        public void Start() {
            GetBeers();
            do
            {
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                for(int i = 0; i < BeerItems.Count; i++) 
                {
                    Console.WriteLine($"[{i+(options.Length)}] - {BeerItems[i].Beer.Name} {BeerItems[i].Keg}%");
                }
                UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "0":
                        break;
                        //View Cart
                    case "1":
                        cartMenu.BreweryId = BreweryID;
                        cartMenu.CustomerId = CustomerId;
                        cartMenu.Start();
                        break;
                    case "2":
                        orderHistoryMenu.BreweryId = BreweryID;
                        orderHistoryMenu.CustomerId = CustomerId;
                        orderHistoryMenu.Start();
                        break;
                    default:
                        try 
                        {
                            BeerItems beeritem = BeerItems[int.Parse(UserInput) - options.Length];
                            orderConfirm.Beer = beeritem.Beer;
                            orderConfirm.Start();
                        } catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }while(!(UserInput == "0"));
            CustomerCartMenu.TableNumber = null;
            CustomerCartMenu.Beers.Clear();
        }

        private void GetBeers() 
        {
            BeerItems = customerService.GetAllBeersByBreweryId(BreweryID);
        }
    }
}