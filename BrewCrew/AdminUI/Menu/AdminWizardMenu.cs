using System;
using System.Collections.Generic;
using BrewCrewLib;
using BrewCrewLib.Users;
using BrewCrewBL;


namespace AdminUI.Menu
{
    public class AdminWizardMenu: IMenuAdmin
    {
        private readonly string[] breweryOptions = {"breweryName"};
        private readonly string[] managerOptions = { "breweryManagerfName", "breweryManagerlName", 
        "email", "password"};
        private readonly string[] locationOptions = {"state", "city", "address", "zip"};  

        public void Start() {
            Dictionary<string, string> breweryAnswers = new Dictionary<string, string>();
            Dictionary<string, string> managerAnswers = new Dictionary<string, string>();
            Dictionary<string, string> locationAnswers = new Dictionary<string, string>();
            Console.WriteLine("Welcome Admin, please enter the brewery information");

            Console.WriteLine("First, lets start with some information about the brewery\n");
            foreach(var option in breweryOptions) {
                breweryAnswers[option] = PromptUserFor(option);
                Console.WriteLine($"\nConfirm {option} : {breweryAnswers[option]}");
            }

            Console.WriteLine("\nGreat! Now lets enter some information about the manager\n");
            foreach(var option in managerOptions) {
                managerAnswers[option] = PromptUserFor(option);
                Console.WriteLine($"\nConfirm {option} : {managerAnswers[option]}");
            }

            Console.WriteLine("\nFinally, lets enter some location information\n");
            foreach(var option in locationOptions) {
                locationAnswers[option] = PromptUserFor(option);
                Console.WriteLine($"\nConfirm {option} : {locationAnswers[option]}");
            }

            BrewCrewBL<Location> brewCrewLocationBl = new BrewCrewBL<Location>("location");
            Location location = new Location();
            location.SetLocation(locationAnswers);
            brewCrewLocationBl.AddData(location);
            brewCrewLocationBl = null;

            BrewCrewBL<Manager> brewCrewManagerBl = new BrewCrewBL<Manager>("manager");
            Manager manager = new Manager();
            manager.SetManager(managerAnswers);
            brewCrewManagerBl.AddData(manager);
            brewCrewManagerBl = null;

            BrewCrewBL<Brewery> brewCrewBreweryBl = new BrewCrewBL<Brewery>("brewery");
            Brewery brewery = new Brewery();
            brewery.SetBrewery(breweryAnswers);
            brewCrewBreweryBl.AddData(brewery);
            brewCrewBreweryBl = null;
            
        }

        private string PromptUserFor(string option) {
            switch (option) {
                case "breweryName":
                    Console.WriteLine("Enter the brewery name");
                    return ValidateBreweryName();
                case "breweryManagerfName":
                    Console.WriteLine("Enter the managers first name");
                    return ValidateManagerName();
                case "breweryManagerlName":
                    Console.WriteLine("Enter the managers last name");
                    return ValidateManagerName();
                case "email":
                    Console.WriteLine("Enter the managers email");
                    return ValidateEmail();
                case "password":
                    Console.WriteLine("Give the manager a temporary password");
                    return ValidatePassword();
                case "state":
                    Console.WriteLine("What state does the brewery reside in?");
                    return ValidateState();
                case "city":
                    Console.WriteLine("What city does the brewery reside in?");
                    return ValidateCity();
                case "address":
                    Console.WriteLine("What is the brewery street address?");
                    return ValidateAddress();
                case "zip":
                    Console.WriteLine("What zipcode does the brewery reside in?");
                    return ValidateZipCode();
                default:
                    // Log this instead of printing to the console
                    Console.WriteLine("Uh oh! the system does not recognize that");
                    return "";
            }

        }

        private string ValidateBreweryName() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }

        private string ValidateManagerName() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }

        private string ValidateEmail() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }

        private string ValidatePassword() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }

        private string ValidateState() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }

        private string ValidateCity() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }

        private string ValidateAddress() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }

        private string ValidateZipCode() {
            string answer;
            while(true) {
                answer = Console.ReadLine();

                // if valid break loop and return
                if (answer != null) {
                    break;
                }
            }
            return answer;
        }
    }
}