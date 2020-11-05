
using BrewCrewDB.Models;
using System.Collections.Generic;
using System;
using BrewCrewDB;
using BrewCrewLib;

namespace ManagerUI.Menu
{
    public class ManagerRefillMenu: IMenuManager
    {
        private string UserInput {get;set;}
        private ManagerService managerService;
        private DBRepo repo;
        private List<BeerItems> BeerItems {get;set;}
        private string BreweryID {get;set;}
        private string BreweryName {get;set;}

        private readonly string[] options = {"Back"};

        public ManagerRefillMenu(string breweryId, string breweryName, DBRepo repo) {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
            this.repo = repo;
            this.managerService = new ManagerService(repo);
        }
        public void Start() {
            GetBeers();
            do
            {
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                for(int i = 0; i <= BeerItems.Count; i++) 
                {
                    Console.WriteLine($"[{i+options.Length}] - {BeerItems[i].Beer.Name} - {BeerItems[i].Keg}%");
                }
                UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "0":
                        break;
                    default:
                        try 
                        {
                            BeerItems beeritem = BeerItems[int.Parse(UserInput) - options.Length];
                            Beer beer = beeritem.Beer;
                            //RefillBeer(beer);
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
            BeerItems = managerService.GetAllBeersByBreweryId(BreweryID);
        }

        private void RefillBeer(Beer beer) {
            // int keg = int.Parse(beer.Keg);
            // keg += 10;
            // beer.Keg = keg.ToString();
            // managerService.UpdateBeer(beer);
        }        
    }
}