using System;

namespace ManagerUI.Menu
{
    
    public class ManagerTaskMenu: IMenu
    {
        private string BreweryName {get; set;}
        private string BreweryID {get; set;}
        private readonly string[] options = {"Add a beer to inventory", "View order history", "Refill keg"};
        public ManagerTaskMenu(string breweryName, string breweryId) 
        {
            this.BreweryName = breweryName;
            this.BreweryID = breweryId;
        }

        public void start() 
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
                case options[0]:
                    ManagerCreateBeerWizard beerWizard = new ManagerCreateBeerWizard(BreweryID);
                    beerWizard.start();
                    break;
                case options[1]:
                    ManagerOrderHistoryMenu orderHistory = new ManagerOrderHistoryMenu(BreweryID);
                    orderHistory.start();
                    break;
                case options[2]:
                    ManagerRefillMenu refillMenu = new ManagerRefillMenu(BreweryID);
                    refillMenu.start();
                default:
                    Console.WriteLine("Uh Oh! The application does not recognize that option, please contact customer support at BrewCrew@brewcrew.net");
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