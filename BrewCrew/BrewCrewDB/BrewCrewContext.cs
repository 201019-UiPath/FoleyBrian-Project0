using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BrewCrewDB.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace BrewCrewDB
{
    public class BrewCrewContext: DbContext
    {
        public DbSet<Beer> Beers {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<BeerItems> BeerItems {get;set;}
        public DbSet<ManagersJoint> Managers {get;set;}
        public DbSet<Brewery> Breweries {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<LineItems> LineItems {get;set;}

        public BrewCrewContext(DbContextOptions<BrewCrewContext> options) : base(options) {
        }

        public BrewCrewContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!(optionsBuilder.IsConfigured))
            {
                var configuration = new ConfigurationBuilder().SetBasePath("/Users/brianfoley/Desktop/FoleyBrian-Project0/BrewCrew/BrewCrewDB")
                .AddJsonFile("appsettings.json").Build();

                var connectionString = configuration.GetConnectionString("BrewCrewDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

        }
    }
}