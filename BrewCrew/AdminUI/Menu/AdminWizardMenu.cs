using System;
using System.Collections.Generic;
using BrewCrewLib;
using BrewCrewDB;
using BrewCrewDB.Models;


namespace AdminUI.Menu
{
    public class AdminWizardMenu: IMenuAdmin
    {
        private object _lockObject = new object();
        private string userInput;
        //private IAdminRepo repo;
        private AdminService adminService;
        //private AdminService AdminService {get;set;}
        private readonly string[] options = {"Create a brewery", "Get all Managers", "Exit"};
        private readonly string[] managerOptions = { "first name", "last name", 
        "email", "password"};
        private readonly string[] breweryOptions = {"name", "state", "city", "address", "zip"};  

        public AdminWizardMenu(IAdminRepo repo)
        {
            //this.repo = repo;
            this.adminService = new AdminService(repo);
        }

        public void Start() {

             do 
            {
                Console.WriteLine("What would you like to do?");
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    //Create a brewery
                    case "0":
                        string breweryId = Guid.NewGuid().ToString();
                        Brewery brewery = GetCreatedBrewery(breweryId);
                        Manager manager = GetCreatedManager(breweryId);
                        brewery.Manager = manager;
                        adminService.AddBrewery(brewery);
                        //adminService.AddManager(manager);
                        break;
                    //Get managers
                    case "1":
                        foreach(var mgr in adminService.GetAllManagers())
                        {
                            Console.WriteLine($"{mgr.FName} {mgr.LName}");
                        }
                        break;
                    //Exit
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                
            }while(!(userInput.Equals((options.Length - 1).ToString())));
        }

        public Manager GetCreatedManager(string breweryId)
        {
            Dictionary<string, object> managerAnswers = new Dictionary<string, object>()
            {
                {"breweryId", breweryId}
            };
            Console.WriteLine("\nGreat! Now lets enter some information about the manager\n");
            for(int i = 0; i < managerOptions.Length; i++) {
                Console.WriteLine($"What is the managers {managerOptions[i]}");
                managerAnswers[managerOptions[i]] = Console.ReadLine();
                Console.WriteLine($"\nConfirm {managerOptions[i]} : {managerAnswers[managerOptions[i]]}");
            }
            Manager manager = new Manager();
            manager.SetManager(managerAnswers);
            return manager;

        }
        public Brewery GetCreatedBrewery(string breweryId)
        {
            Dictionary<string, object> breweryAnswers = new Dictionary<string, object>()
            {
                {"id", breweryId}
            };
            Console.WriteLine("First, lets start with some information about the brewery\n");
            for(int i = 0; i < breweryOptions.Length; i++) {
                 Console.WriteLine($"What is the brewery's {breweryOptions[i]}");
                breweryAnswers[breweryOptions[i]] = Console.ReadLine();
                Console.WriteLine($"\nConfirm {breweryOptions[i]} : {breweryAnswers[breweryOptions[i]]}");
            }
            Brewery brewery = new Brewery();
            brewery.SetBrewery(breweryAnswers);
            return brewery;
        }
    }
}
