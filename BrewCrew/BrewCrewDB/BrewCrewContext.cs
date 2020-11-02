using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BrewCrewDB.Models;
using System.IO;


namespace BrewCrewDB
{
    public class BrewCrewContext: DbContext
    {
        public DbSet<Beer> Beers {get;set;}
        public DbSet<Manager> Managers {get;set;}
        public DbSet<Customer> Customers{get;set;}
        public DbSet<Brewery> Breweries {get;set;}
        public DbSet<Order> Orders{get;set;}
        //public DbSet<OrderLink> OrderLink{get;set;}
        //.... add additional model lists

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
            //modelBuilder.Entity<Beer>().HasMany(e => e.ID).WithMany(order => order.id).HasForeignKey(e => e.BeerId);

            // modelBuilder.Entity<OrderLink>()
            // .HasOne(l => l.Beer)
            // .WithMany(b => b.Link)
            // .HasForeignKey(ob => ob.BeerId);

            // modelBuilder.Entity<OrderLink>()
            // .HasOne(ob => ob.Order)
            // .WithMany(o => o.Link)
            // .HasForeignKey(ob => ob.OrderId);

            // modelBuilder.Entity<OrderLink>()
            //  .HasOne(ob => ob.Brewery)
            // .WithMany(br => br.Link)
            // .HasForeignKey(ob => ob.BreweryId);

            // modelBuilder.Entity<Order>()
            // .HasOne(o => o.Customer)
            // .WithMany(c => c.Order)
            // .HasForeignKey(o => o.CustomerID);

            // modelBuilder.Entity<Order>()
            // .HasMany(o => o.Beers)
            // .WithOne(br => br.order)
            // .HasForeignKey(o => o.ID);
            
            modelBuilder.Entity<Beer>()
            .HasOne(b => b.Brewery)
            .WithMany(br => br.Beers)
            .HasForeignKey(b => b.BreweryID);

            modelBuilder.Entity<Manager>()
            .HasOne(b => b.Brewery)
            .WithOne(br => br.Manager)
            .HasForeignKey<Manager>(b => b.BreweryID);

            // modelBuilder.Entity<Brewery>()
            // .HasOne(b => b.Brewery)
            // .WithOne(br => br.Manager)
            // .HasForeignKey<Manager>(b => b.BreweryID);


        }
    }
}