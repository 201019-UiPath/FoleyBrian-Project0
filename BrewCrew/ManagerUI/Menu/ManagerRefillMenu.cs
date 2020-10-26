namespace ManagerUI.Menu
{
    public class ManagerRefillMenu: IMenu
    {
        private string BreweryID {get;set;}
        private string BreweryName {get;set;}

        public ManagerRefillMenu(string breweryId, string breweryName) {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
        }
        public void start() {
            
        }
        
    }
}