namespace BrewCrewDB.Models
{
    public class LineItems
    {
        public string ID {get;set;}
        public string OrderID {get;set;}
        public Order Order {get;set;}
        public string BeerID {get;set;}
        public Beer Beer {get;set;}
    }
}