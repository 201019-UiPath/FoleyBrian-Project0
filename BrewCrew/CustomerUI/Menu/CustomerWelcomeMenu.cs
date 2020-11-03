using System;
using System.Collections.Generic;
using BrewCrewDB.Models;
using BrewCrewDB;
using BrewCrewLib;
using Serilog;

namespace CustomerUI.Menu
{
    public class CustomerWelcomeMenu: IMenuCustomer
    {
        private CustomerCreateUserWizard createUserWizard;
        private IMenuCustomer loginWizard;
        private string UserInput {get;set;}
        private CustomerService customerService;
        private DBRepo repo;
        private List<Brewery> Breweries {get;set;}
        private readonly string[] options = {"Back", "Login", "Register"};
        public CustomerWelcomeMenu(DBRepo repo)
        {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.createUserWizard = new CustomerCreateUserWizard(repo);
            this.loginWizard = new CustomerLoginWizard(repo);
        }
        public void Start() 
        {
            do 
            {
                Console.WriteLine("Welcome to Brew Crew! Please Login or Register\n");
                for(int i = 0; i < options.Length; i++) 
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                UserInput = Console.ReadLine();
                switch(UserInput)
                {
                    case "0":
                        break;
                        //Login
                    case "1":
                        loginWizard.Start();
                        break;
                        //Register
                    case "2":
                        createUserWizard.Start();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }while(!(UserInput == "0"));
        }  
    }
}