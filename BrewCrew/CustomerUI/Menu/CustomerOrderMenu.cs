using System;
using System.Collections.Generic;
using BrewCrewLib;
using BrewCrewBL;

namespace CustomerUI.Menu
{
    public class CustomerOrderMenu: IMenuCustomer
    {
       private List<Beer> Beers {get;set;}
        private List<Beer> FilteredBeers;
        private string BreweryID {get;set;}
        private string BreweryName {get;set;}

        public CustomerOrderMenu(string breweryId, string breweryName) {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
        }
        public void Start() {
            GetBeers();
            Console.WriteLine("Order a beer");
                for(int i = 0; i < FilteredBeers.Count; i++) 
                {
                    Console.WriteLine($"[{i}] - {FilteredBeers[i].Name} - {FilteredBeers[i].Keg}");
                }
                int answer = ValidateOption();
                Beer beer = FilteredBeers[answer];
                CustomerOrderConfirm confirmMenu = new CustomerOrderConfirm(beer);
                confirmMenu.Start();
        }

        private void GetBeers() 
        {
            BrewCrewBL<Beer> bl = new BrewCrewBL<Beer>("beer");
            Beers = bl.GetAllListData();
            bl = null;
            FilterBeersByBrewery();
        }

        private void FilterBeersByBrewery() {
            FilteredBeers = Beers.FindAll(brew => brew.BreweryID == BreweryID);
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