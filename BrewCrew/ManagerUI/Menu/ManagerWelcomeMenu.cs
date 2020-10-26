using System;
using BrewCrewBL;
using System.Collections.Generic;
using BrewCrewLib;

namespace ManagerUI.Menu
{
    public class ManagerWelcomeMenu: IMenu
    {
        private List<Brewery> breweries;
        public void start() 
        {
            getBreweries();
            Console.WriteLine("Welcome Manager! Please Select your brewery");
                for(int i = 0; i < breweries.Count; i++) 
                {
                    Console.WriteLine($"[{i}] - {breweries[i].Name}");
                }
                int answer = ValidateOption();
                string breweryName = breweries[answer].Name;
                string breweryId = breweries[answer].ID;
                ManagerTaskMenu taskMenu = new ManagerTaskMenu(breweryName, breweryId);
                taskMenu.start();
        }

        private void getBreweries() 
        {
            Brewery brewery = new Brewery();
            BrewCrewBL<Brewery> bl = new BrewCrewBL<Brewery>("brewery");
            breweries = bl.GetAllListData();
            brewery = null;
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