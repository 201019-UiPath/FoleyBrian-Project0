using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BrewCrewDB.Models;


namespace BrewCrewDB
{
    public class BrewCrewContext: DbContext
    {
        public DbSet<Beer> Beers {get;set;}
        public DbSet<Manager> Managers {get;set;}
        public DbSet<Customer> Customers{get;set;}
        public DbSet<Brewery> Breweries {get;set;}
        public DbSet<Order> Orders{get;set;}

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
            modelBuilder.Entity<Beer>()
            .HasOne(b => b.Brewery)
            .WithMany(br => br.Beers)
            .HasForeignKey(b => b.BreweryID);

            modelBuilder.Entity<Manager>()
            .HasOne(b => b.Brewery)
            .WithOne(br => br.Manager)
            .HasForeignKey<Manager>(b => b.BreweryID);
        }
    }
}