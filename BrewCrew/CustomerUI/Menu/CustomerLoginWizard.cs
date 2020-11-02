using BrewCrewDB;
using BrewCrewDB.Models;
using BrewCrewLib;
using System;

namespace CustomerUI.Menu
{
    public class CustomerLoginWizard: IMenuCustomer
    {
        private string UserInput {get;set;}
        private DBRepo repo;
        private CustomerService customerService;
        private CustomerBrewerySelection brewerySelection;
        private readonly string[] options = {"Back"};
        
        public CustomerLoginWizard(DBRepo repo)
        {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.brewerySelection = new CustomerBrewerySelection(repo);
        }

        public void Start()
        {
            bool loginSuccess = false;
            do
            {
                // Detecting emails ^\w+@\w+.(com|net|gov|edu)$
                Console.WriteLine("Please Enter your Email");
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "0":
                        break;
                    default:
                        loginSuccess = HandleLogin();
                        break;
                }
            }while(!(UserInput == "0" || loginSuccess));
        }

        private bool HandleLogin()
        {

            Customer user = customerService.GetUserByEmail(UserInput);
            if (user != null)
            {
                Console.WriteLine("Successfully Logged in");
                brewerySelection.CustomerId= user.ID;
                brewerySelection.Start();
                return true;
            } else 
            {
                Console.WriteLine("Login Failed");
                return false;
            }
        }
    }
}