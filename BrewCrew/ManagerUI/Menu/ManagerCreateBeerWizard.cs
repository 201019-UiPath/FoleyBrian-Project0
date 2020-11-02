using System;
using BrewCrewDB.Models;
using System.Collections.Generic;
using BrewCrewDB;
using BrewCrewLib;

namespace ManagerUI.Menu
{
    public class ManagerCreateBeerWizard: IMenuManager
    {
        private string UserInput {get;set;}
        private DBRepo repo;
        private ManagerService managerService;
        private string BreweryID {get; set;}
        private string BreweryName {get;set;}
        private readonly string[] beerDescriptionOptions = {"name", "abv", "ibu", "type"};

        public ManagerCreateBeerWizard(string breweryId, string breweryName, DBRepo repo) {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
            this.repo = repo;
            this.managerService = new ManagerService(repo);
        }

        public void Start() {
            Beer beer = GetCreatedBeer();
            managerService.AddBeer(beer);
        }

        public Beer GetCreatedBeer()
        {
            Dictionary<string, string> answers = new Dictionary<string, string>();
            answers["breweryId"] = BreweryID;
            
            foreach(var option in beerDescriptionOptions) {
                Console.WriteLine($"Enter the {option} of the beer.\n");
                answers[option] = Console.ReadLine();
                Console.WriteLine($"\nConfirm {option} : {answers[option]}");
            }
            Beer beer = new Beer();
            beer.SetBeer(answers);
            return beer;
        }
    }
}