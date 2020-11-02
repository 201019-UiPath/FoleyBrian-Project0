using BrewCrewDB;
using BrewCrewDB.Models;
using BrewCrewLib;
using System;
using System.Collections.Generic;

namespace CustomerUI.Menu
{
    public class CustomerBrewerySelection: IMenuCustomer
    {
        private CustomerOrderMenu orderMenu;
        public string CustomerId {get;set;}
        private List<Brewery> Breweries {get;set;}
        private string UserInput {get;set;}
        private DBRepo repo;
        private CustomerService customerService;
        private readonly List<string> options = new List<string>()
        {
             "Back"
        };


        public CustomerBrewerySelection(DBRepo repo)
        {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.orderMenu = new CustomerOrderMenu(repo);
        }

        public void Start()
        {
            GetBreweries();
            do
            {
                Console.WriteLine("Select A Brewery");
                for(int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "0":
                        break;
                    default:
                         try
                        {
                            Brewery brewery = Breweries[int.Parse(UserInput) - 1];
                            orderMenu.BreweryID = brewery.ID;
                            orderMenu.BreweryName = brewery.Name;
                            orderMenu.CustomerId = CustomerId;
                            orderMenu.Start();
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }while(!(UserInput == "0"));
        }

        private void GetBreweries() 
        {
            Breweries = customerService.GetAllBreweries();
            foreach(var brew in Breweries)
            {
                options.Add(brew.Name);
            }
        }        
    }
}