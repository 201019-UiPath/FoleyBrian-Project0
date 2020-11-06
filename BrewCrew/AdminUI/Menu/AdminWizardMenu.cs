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
        private readonly string[] options = {"Back", "Create a brewery", "Get all Managers"};
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
                        //Exit
                    case "0":
                        break;
                        //Create a brewery
                    case "1":
                        string breweryId = Guid.NewGuid().ToString();
                        Brewery brewery = GetCreatedBrewery(breweryId);
                        User manager = GetCreatedManager(breweryId);
                        ManagersJoint managers = new ManagersJoint(){
                            ID = Guid.NewGuid().ToString(),
                            BreweryID = brewery.ID,
                            Brewery = brewery,
                            User = manager
                            
                        };
                        adminService.AddBreweryManager(managers);
                       
                        break;
                        //Get managers
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Here is a list of all managers:");
                        foreach(var mgr in adminService.GetAllManagers())
                        {
                            Console.WriteLine($"{mgr.FName} {mgr.LName}");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                
            }while(!(userInput == "0"));
        }

        public User GetCreatedManager(string breweryId)
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
                Console.WriteLine();
            }
            User manager = new User() 
            {
                ID = Guid.NewGuid().ToString(),
                FName = (string)managerAnswers["first name"],
                LName = (string)managerAnswers["last name"],
                Email = (string)managerAnswers["email"],
                Password = (string)managerAnswers["password"],
                Type = "manager"
            };
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
                Console.WriteLine();
                Console.WriteLine($"\nConfirm {breweryOptions[i]} : {breweryAnswers[breweryOptions[i]]}");
            }
            Brewery brewery = new Brewery()
            {
                ID = Guid.NewGuid().ToString(),
                Name = (string)breweryAnswers["name"],
                State = (string)breweryAnswers["state"],
                City = (string)breweryAnswers["city"],
                Address = (string)breweryAnswers["address"],
                Zip = (string)breweryAnswers["zip"],
            };
            return brewery;
        }
    }
}
