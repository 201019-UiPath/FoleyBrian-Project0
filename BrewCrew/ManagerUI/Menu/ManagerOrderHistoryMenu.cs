
namespace ManagerUI.Menu
{
    public class ManagerOrderHistoryMenu: IMenu
    {
        private string BreweryID {get;set;}
        private string BreweryName {get;set;}

        public ManagerOrderHistoryMenu(string breweryId, string breweryName) {
            this.BreweryID = breweryId;
            this.BreweryName = breweryName;
        }

        public void Start() {
            GetOrders();
        }

        public void GetOrders() {

        }

    }
}