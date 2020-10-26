using BrewCrew.Menu;
using AdminUI;
using ManagerUI;
using CustomerUI;

namespace BrewCrew
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Start();
        }
    }
}
