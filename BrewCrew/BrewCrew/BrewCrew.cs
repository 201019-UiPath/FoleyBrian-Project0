using BrewCrew.Menu;
using BrewCrewDB;
using Serilog;


namespace BrewCrew
{
    class BrewCrew
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/logs.txt")
                .CreateLogger();
            MainMenu mainMenu = new MainMenu(new BrewCrewContext());
            mainMenu.Start();
        }
    }
}
