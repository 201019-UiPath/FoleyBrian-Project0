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
            Customer customer = GetCreatedCustomer();
            customerService.AddCustomer(customer);
        }

        public Customer GetCreatedCustomer()
        {
            Dictionary<string, object> customerAnswers = new Dictionary<string, object>();
            Console.WriteLine("\nGreat! Now lets enter some information about the manager\n");
            for(int i = 0; i < customerOptions.Length; i++) {
                Console.WriteLine($"What is your {customerOptions[i]}");
                customerAnswers[customerOptions[i]] = Console.ReadLine();
                Console.WriteLine($"\nConfirm {customerOptions[i]} : {customerAnswers[customerOptions[i]]}");
                Console.ReadLine();
            }
            Customer customer = new Customer();
            customer.SetCustomer(customerAnswers);
            return customer;

        }
    }
}