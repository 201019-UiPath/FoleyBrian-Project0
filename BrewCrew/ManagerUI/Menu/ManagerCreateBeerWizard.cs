namespace ManagerUI.Menu
{
    public class ManagerCreateBeerWizard: IMenu
    {
        private string BreweryID {get; set;}

        public ManagerCreateBeerWizard(string breweryId) {
            this.BreweryID = breweryId;
        }

        public void start() {

        }
    }
}