using System;

namespace CustomerUI.Menu
{
    public class CustomerTableNumberPrompt: IMenuCustomer
    {
        private string BreweryID {get; set;}
        private string BreweryName {get; set;}

        public CustomerTableNumberPrompt(string breweryId, string breweryName)
        {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
        }
        public void Start()
        {
            Console.WriteLine("What is your table number?");
            Cart.TableNumber = ValidateOption();
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