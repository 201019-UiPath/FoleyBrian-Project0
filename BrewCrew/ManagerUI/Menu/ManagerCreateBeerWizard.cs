using System;
using BrewCrewBL;
using BrewCrewLib;
using System.Collections.Generic;

namespace ManagerUI.Menu
{
    public class ManagerCreateBeerWizard: IMenuManager
    {
        private string BreweryID {get; set;}
        private string BreweryName {get;set;}

        private readonly string[] beerDescriptionOptions = {"name", "abv", "ibu", "type"};

        public ManagerCreateBeerWizard(string breweryId, string breweryName) {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
        }

        public void Start() {
            Dictionary<string, string> answers = new Dictionary<string, string>();
            answers["breweryId"] = BreweryID;
            
            foreach(var option in beerDescriptionOptions) {
                Console.WriteLine($"Enter the {option} of the beer.\n");
                answers[option] = PromptUserFor(option);
                Console.WriteLine($"\nConfirm {option} : {answers[option]}");
            }

            BrewCrewBL<Beer> brewCrewBeerBl = new BrewCrewBL<Beer>("beer");
            Beer beer = new Beer();
            beer.SetBeer(answers);
            brewCrewBeerBl.AddData(beer);
            brewCrewBeerBl = null;

            //ManagerTaskMenu taskMenu = new ManagerTaskMenu(BreweryID, BreweryName);
            //taskMenu.Start();
        }

        private string PromptUserFor(string option) {
            switch (option) {
                case "name":
                    return ValidateBeerName();
                case "abv":
                    return ValidateAbv();
                case "ibu":
                    return ValidateIbu();
                case "type":
                    return ValidateType();
                default:
                    // Log this instead of printing to the console
                    Console.WriteLine("Uh oh! the system does not recognize that. Please contact customer support at BrewCrew@brewcrew.net");
                    return "";
            }

        }

        private string ValidateBeerName() 
        {
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

        private string ValidateAbv() 
        {
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

        private string ValidateIbu() 
        {
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

        private string ValidateType() 
        {
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