using BrewCrewDB;
using BrewCrewDB.Models;
using BrewCrewLib;
using System;
using System.Collections.Generic;

namespace CustomerUI.Menu
{
    public class CustomerCreateUserWizard: IMenuCustomer
    {
        private string UserInput {get;set;}
        private DBRepo repo;
        private CustomerService customerService;
         private readonly string[] customerOptions = { "first name", "last name", 
        "email", "password"};
   
        public CustomerCreateUserWizard(DBRepo repo)
        {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
        }

        public void Start()
        {
            User customer = GetCreatedCustomer();
            customerService.AddCustomer(customer);
        }

        public User GetCreatedCustomer()
        {
            Dictionary<string, object> customerAnswers = new Dictionary<string, object>();
            Console.WriteLine("\nGreat! Now lets enter some information about the manager\n");
            for(int i = 0; i < customerOptions.Length; i++) {
                Console.WriteLine($"What is your {customerOptions[i]}");
                customerAnswers[customerOptions[i]] = Console.ReadLine();
                Console.WriteLine($"\nConfirm {customerOptions[i]} : {customerAnswers[customerOptions[i]]}");
                Console.WriteLine();
            }
            User customer = new User(){
                ID = Guid.NewGuid().ToString(),
                FName = (string)customerAnswers["first name"],
                LName = (string)customerAnswers["last name"],
                Email = (string)customerAnswers["email"],
                Password = (string)customerAnswers["password"]
            };
            //customer.SetCustomer(customerAnswers);
            return customer;

        }
    }
}