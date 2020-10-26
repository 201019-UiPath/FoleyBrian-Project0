using System;
using System.Collections.Generic;
using BrewCrewLib;
using BrewCrewBL;

namespace CustomerUI.Menu
{
    public class CustomerWelcomeMenu: IMenuCustomer
    {
        // private string BreweryName {get;set;}
        // private string BreweryId {get;set;}
        private List<Brewery> Breweries {get;set;}
        private Dictionary<string,string> BaseOptions = new Dictionary<string,string>()
        {
            {"cart", "View Cart"},
            {"orders","View Orders"}
        };

        private bool IsBaseOption {get; set;}

        public void Start() 
        {
            GetBreweries();
            Console.WriteLine("Welcome to BrewCrew! Please Select a brewery");
            foreach(var item in BaseOptions)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            Console.WriteLine();

            for(int i = 0; i < Breweries.Count; i++) 
            {
                Console.WriteLine($"[{i}] - {Breweries[i].Name}");
            }
            int answer = ValidateOption();
            //CheckAnswer(answer);
            //CustomerOrderMenu orderMenu = new CustomerOrderMenu(BreweryName, BreweryId);
            //orderMenu.Start();
        }

        private void GetBreweries() 
        {
            List<Brewery> breweryList;
            BrewCrewBL<Brewery> bl = new BrewCrewBL<Brewery>("brewery");
            breweryList = bl.GetAllListData();
            bl = null;
            //add brewery options to list
            foreach(var brewery in breweryList) {
                Breweries.Add(brewery);
            }
            
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