using System;
using BrewCrewDB;

namespace ManagerUI.Menu
{
    
    public class ManagerTaskMenu: IMenuManager
    {
        private DBRepo repo;
        private string UserInput {get;set;}
        public string BreweryName {get; set;}
        public string BreweryID {get; set;}
        private readonly string[] options = {"Back", "Add a beer to inventory", "Refill keg", "View order history"};
        public ManagerTaskMenu(DBRepo repo) 
        {
            this.repo = repo;
        }

        public void Start() 
        {
            do {
                Console.WriteLine("What would you like to do?");
                for(int i = 0; i < options.Length; i++) 
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    //Go Back
                    case "0":
                        break;
                    //Add Beer
                    case "1":
                        ManagerCreateBeerWizard beerWizard = new ManagerCreateBeerWizard(BreweryID, BreweryName, repo);
                        beerWizard.Start();
                        break;
                    //Fill Keg
                    case "2":
                        ManagerRefillMenu refillMenu = new ManagerRefillMenu(BreweryID, BreweryName, repo);
                        refillMenu.Start();
                        break;
                    //View Inventory History
                    case "3":
                        ManagerOrderHistoryMenu orderHistory = new ManagerOrderHistoryMenu(repo);
                        orderHistory.BreweryID = BreweryID;
                        orderHistory.BreweryName = BreweryName;
                        orderHistory.Start();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }while(!(UserInput == "0"));
        }        
    }
}