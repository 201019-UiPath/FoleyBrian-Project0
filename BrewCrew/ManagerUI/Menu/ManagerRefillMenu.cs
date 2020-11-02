
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
        private List<Beer> Beers {get;set;}
        private string BreweryID {get;set;}
        private string BreweryName {get;set;}

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
                Console.WriteLine("Select a keg to refill");
                Console.WriteLine("[0] - Back");
                for(int i = 1; i <= Beers.Count; i++) 
                {
                    Console.WriteLine($"[{i}] - {Beers[i-1].Name} - {Beers[i-1].Keg}%");
                }
                UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "0":
                        break;
                    default:
                        try 
                        {
                            Beer beer = Beers[int.Parse(UserInput)-1];
                            RefillBeer(beer);
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
            Beers = managerService.GetAllBeersByBreweryId(BreweryID);
        }

        private void RefillBeer(Beer beer) {
            int keg = int.Parse(beer.Keg);
            keg += 10;
            beer.Keg = keg.ToString();
            managerService.UpdateBeer(beer);
        }        
    }
}