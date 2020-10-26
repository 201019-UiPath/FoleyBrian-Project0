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
            keg = 100; //can do incremental logic here instead. Check value is between -1 and 101
            string strKeg = keg.ToString();
            //create a copy of a beer object then replace it in the array. This is because it is a struct (value type).
            Dictionary<string,string> dataInput = new Dictionary<string,string>();
            //"name", "abv", "ibu" "breweryId", "type"
            dataInput["name"] = FilteredBeers[answer].Name;
            dataInput["abv"] = FilteredBeers[answer].ABV;
            dataInput["ibu"] = FilteredBeers[answer].IBU;
            dataInput["breweryId"] = this.BreweryID;
            dataInput["type"] = FilteredBeers[answer].Type;
            dataInput["id"] = FilteredBeers[answer].ID;
            dataInput["keg"] = strKeg;
            Beer beer = new Beer();
            beer.SetBeer(dataInput);

            Beers[Beers.FindIndex(brew => brew.ID == FilteredBeers[answer].ID)] = beer;
            
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