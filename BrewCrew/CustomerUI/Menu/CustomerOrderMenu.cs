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
        private string UserInput {get;set;}
        DBRepo repo;
        CustomerService customerService;
        private CustomerCartMenu cartMenu;
        private List<Beer> Beers {get;set;}
         private readonly string[] options = {"Back", "View Cart"};
        public string BreweryID {get;set;}
        public string BreweryName {get;set;}
        public string CustomerId {get;set;}

        public CustomerOrderMenu(DBRepo repo) {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.orderConfirm = new CustomerOrderConfirm();
            this.cartMenu = new CustomerCartMenu(repo);
        }
        public void Start() {
            GetBeers();
            do
            {
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                Console.WriteLine();
                for(int i = 0; i < Beers.Count; i++) 
                {
                    Console.WriteLine($"[{i+(options.Length)}] - {Beers[i].Name} - {Beers[i].Keg}%");
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
                    default:
                        try 
                        {
                            Beer beer = Beers[int.Parse(UserInput) - options.Length];
                            orderConfirm.Beer = beer;
                            orderConfirm.Start();
                        } catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }while(!(UserInput == "0"));
        }

        private void GetBeers() 
        {
             Beers = customerService.GetAllBeersByBreweryId(BreweryID);
        }
    }
}