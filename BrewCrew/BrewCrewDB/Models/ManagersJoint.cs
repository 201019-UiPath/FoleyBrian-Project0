
namespace BrewCrewDB.Models
{
    public class ManagersJoint
    {
        public string ID {get;set;}
        public string BreweryID {get;set;}
        public Brewery Brewery {get;set;}
        public User User {get;set;}
    }
}