using AdminUI.Menu;
using ManagerUI.Menu;
using CustomerUI.Menu;
using System;

namespace BrewCrew.Menu
{
    public class MainMenu: IMenu
    {
        private readonly string[] options = {"Admin", "Manager", "Customer"};

        public void Start() 
        {
            Console.WriteLine("What would you like to do?");
            for(int i = 0; i < options.Length; i++) 
            {
                Console.WriteLine($"[{i}] - {options[i]}");
            }
            int answer = ValidateOption();
            string strAnswer = options[answer];
            switch(strAnswer) 
            {
                case "Admin":
                    IMenuAdmin adminMenu = new AdminWizardMenu();
                    adminMenu.Start();
                    break;
                case "Manager":
                    IMenuManager managerMenu = new ManagerWelcomeMenu();
                    managerMenu.Start();
                    break;
                case "Customer":
                    IMenuCustomer customerMenu = new CustomerWelcomeMenu();
                    customerMenu.Start();
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