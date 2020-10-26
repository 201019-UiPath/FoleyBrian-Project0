using System;

namespace ManagerUI.Menu
{
    
    public class ManagerTaskMenu: IMenuManager
    {
        private string BreweryName {get; set;}
        private string BreweryID {get; set;}
        private readonly string[] options = {"Add a beer to inventory", "View order history", "Refill keg"};
        public ManagerTaskMenu(string breweryName, string breweryId) 
        {
            this.BreweryName = breweryName;
            this.BreweryID = breweryId;
        }

        public void Start() 
        {
            Console.WriteLine("What would you like to do?");
            for(int i = 0; i < options.Length; i++) 
            {
                Console.WriteLine($"{i} - {options[i]}");
            }
            int answer = ValidateOption();
            string strAnswer = options[answer];
            switch(strAnswer) 
            {
                case "Add a beer to inventory":
                    ManagerCreateBeerWizard beerWizard = new ManagerCreateBeerWizard(BreweryID, BreweryName);
                    beerWizard.Start();
                    break;
                case "View order history":
                    ManagerOrderHistoryMenu orderHistory = new ManagerOrderHistoryMenu(BreweryID, BreweryName);
                    orderHistory.Start();
                    break;
                case "Refill keg":
                    ManagerRefillMenu refillMenu = new ManagerRefillMenu(BreweryID, BreweryName);
                    refillMenu.Start();
                    break;
                default:
                    Console.WriteLine("Uh oh! the system does not recognize that. Please contact customer support at BrewCrew@brewcrew.net");
                    break;
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