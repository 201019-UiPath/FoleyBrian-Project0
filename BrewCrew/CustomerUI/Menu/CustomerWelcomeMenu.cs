using System;
using System.Collections.Generic;
using BrewCrewLib;
using BrewCrewBL;

namespace CustomerUI.Menu
{
    public class CustomerWelcomeMenu: IMenuCustomer
    {
        private List<Brewery> Breweries {get;set;}
        private List<string> Options {get;set;}
        // private Dictionary<string,string> BaseOptions = new Dictionary<string,string>()
        // {
        //     {"cart", "View Cart"},
        //     {"orders","View Orders"}
        // };

        public void Start() 
        {
            GetBreweries();
            Console.WriteLine("Welcome to BrewCrew! Please Select a brewery\n");

            for(int i = 0; i < Breweries.Count; i++) 
            {
                Console.WriteLine($"[{i}] - {Breweries[i].Name}");
            }
            int answer = ValidateOption();
            string BreweryName = Breweries[answer].Name;
            string BreweryId = Breweries[answer].ID;
            CustomerOrderMenu orderMenu = new CustomerOrderMenu(BreweryId, BreweryName);
            orderMenu.Start();
        }

        private void GetBreweries() 
        {
            BrewCrewBL<Brewery> bl = new BrewCrewBL<Brewery>("brewery");
            Breweries = bl.GetAllListData();
            bl = null;
        }

        private int ValidateOption() 
        {
            int answer;
            while(true) {
                answer = int.Parse(Console.ReadLine());

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }
        
    }
}