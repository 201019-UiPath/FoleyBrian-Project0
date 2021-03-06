using System;
using System.Collections.Generic;
using BrewCrewDB.Models;
using BrewCrewDB;
using BrewCrewLib;

namespace ManagerUI.Menu
{
    public class ManagerWelcomeMenu: IMenuManager
    {
        private string UserInput {get;set;}
        ManagerTaskMenu taskMenu;
        private DBRepo repo;
        private ManagerService managerService;
        private List<Brewery> Breweries {get; set;}
        private readonly List<string> options = new List<string>()
        {
            "Back"
        };
        public ManagerWelcomeMenu(DBRepo repo)
        {
            this.repo = repo;
            this.managerService = new ManagerService(repo);
            this.taskMenu = new ManagerTaskMenu(repo);
        }
        public void Start() 
        {
            GetBreweries();
            do {
                Console.WriteLine("Welcome Manager, Please Select your Brewery");
                for(int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                UserInput = Console.ReadLine();
                switch(UserInput)
                {
                    case "0":
                        break;
                    default:
                        try
                        {
                            Brewery brewery = Breweries[int.Parse(UserInput) - 1];
                            taskMenu.BreweryID = brewery.ID;
                            taskMenu.BreweryName = brewery.Name;
                            taskMenu.Start();
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
            Breweries = managerService.GetAllBreweries();
            foreach(var brew in Breweries)
            {
                options.Add(brew.Name);
            }
        }
    }
}