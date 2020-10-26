using BrewCrewBL;
using BrewCrewLib;
using System.Collections.Generic;
using System;

namespace ManagerUI.Menu
{
    public class ManagerRefillMenu: IMenu
    {
        private List<Beer> Beers {get;set;}
        private List<Beer> FilteredBeers;
        private string BreweryID {get;set;}
        private string BreweryName {get;set;}

        public ManagerRefillMenu(string breweryId, string breweryName) {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
        }
        public void Start() {
            GetBeers();
            Console.WriteLine("Select a keg to refill");
                for(int i = 0; i < FilteredBeers.Count; i++) 
                {
                    Console.WriteLine($"[{i}] - {FilteredBeers[i].Name} - {FilteredBeers[i].Keg}");
                }
                int answer = ValidateOption();
                RefillBeer(answer);
                //ManagerTaskMenu taskMenu = new ManagerTaskMenu(BreweryName, BreweryID);
                //taskMenu.Start();
        }

        private void GetBeers() 
        {
            Beer beer = new Beer();
            BrewCrewBL<Beer> bl = new BrewCrewBL<Beer>("beer");
            Beers = bl.GetAllListData();
            bl = null;
            FilterBeersByBrewery();
        }

        private void FilterBeersByBrewery() {
            FilteredBeers = Beers.FindAll(brew => brew.BreweryID == BreweryID);
        }

        private void RefillBeer(int answer) {
            int keg = int.Parse(FilteredBeers[answer].Keg);
            keg = 100;
            string strKeg = keg.ToString();
            FilteredBeers[answer].Keg = strKeg;
            Beers[Beers.FindIndex(brew => brew.ID == FilteredBeers[answer].ID)] = FilteredBeers[answer];
            Beer beer = new Beer();
            BrewCrewBL<Beer> bl = new BrewCrewBL<Beer>("beer");
            bl.ReplaceData(Beers);
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