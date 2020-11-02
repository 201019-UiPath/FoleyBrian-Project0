using AdminUI.Menu;
using ManagerUI.Menu;
using CustomerUI.Menu;
using System;
using BrewCrewDB;

namespace BrewCrew.Menu
{
    public class MainMenu: IMenu
    {
        private AdminWizardMenu adminMenu;
        private ManagerWelcomeMenu managerMenu;
        private CustomerWelcomeMenu customerMenu;
        private string userInput;
        private readonly string[] options = {"Admin", "Manager", "Customer", "Exit"};

        public MainMenu(BrewCrewContext context)
        {
            this.adminMenu = new AdminWizardMenu(new DBRepo(context));
            this.managerMenu = new ManagerWelcomeMenu(new DBRepo(context));
            this.customerMenu = new CustomerWelcomeMenu(new DBRepo(context));
        }
        public void Start() 
        {
            do 
            {
                Console.WriteLine("Welcome! What are you?");
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        adminMenu.Start();
                        break;
                    case "1":
                        managerMenu.Start();
                        break;
                    case "2":
                        customerMenu.Start();
                        break;
                    case "3":
                        Console.WriteLine("GoodBye");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }while(!(userInput.Equals((options.Length - 1).ToString())));
        }

    }
}