using System;
using BrewCrewBL;
using System.Collections.Generic;
using BrewCrewLib;

namespace ManagerUI.Menu
{
    public class ManagerWelcomeMenu: IMenu
    {
        private List<Brewery> Breweries {get; set;}
        public void Start() 
        {
            GetBreweries();
            Console.WriteLine("Welcome Manager! Please Select your brewery");
                for(int i = 0; i < Breweries.Count; i++) 
                {
                    Console.WriteLine($"[{i}] - {Breweries[i].Name}");
                }
                int answer = ValidateOption();
                string breweryName = Breweries[answer].Name;
                string breweryId = Breweries[answer].ID;
                ManagerTaskMenu taskMenu = new ManagerTaskMenu(breweryName, breweryId);
                taskMenu.Start();
        }

        private void GetBreweries() 
        {
            Brewery brewery = new Brewery();
            BrewCrewBL<Brewery> bl = new BrewCrewBL<Brewery>("brewery");
            Breweries = bl.GetAllListData();
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