using BrewCrew.Menu;
using BrewCrewDB;

namespace BrewCrew
{
    class BrewCrew
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu(new BrewCrewContext());
            mainMenu.Start();
        }
    }
}
