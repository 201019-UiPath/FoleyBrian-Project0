using System;
using Xunit;
using BrewCrewLib;
using BrewCrewDB.Models;
using BrewCrewDB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BrewCrewTest
{
    public class DBTest
    {
        DBRepo repo;

        private readonly Customer TestCustomer = new Customer()
        {
            ID = "1",
            FName = "Michael",
            LName = "Scott",
            Email = "customer1@email.net",
            Password = "qqqqqq"
        };
        private readonly Manager TestManager = new Manager()
        {
            ID = "1",
            FName = "John",
            LName = "Deer",
            Email = "manager1@email.net",
            Password = "qqqqqq",
            BreweryID = "1"
        };
        private readonly Brewery TestBrewery = new Brewery()
        {
                ID = "1",
                Name = "Lewis and Clark Brewery",
                State = "MT",
                City = "Helena",
                Address = "123 Beer Ave",
                Zip = "12345"
        };

        private readonly Beer TestBeer = new Beer()
        {
                ID = "1",
                BreweryID = "1",
                Name = "White Stout",
                Type = "Stout",
                ABV = "9.5",
                IBU = "44",
                Keg = "100"
        };

        private readonly Order TestOrder = new Order()
        {
            ID = "1",
            CustomerID = "1",
            BeerId = "1",
            Date = DateTime.Now.ToString(),
            TableNumber = "1",
            BreweryId = "1",
            LineItemId = "1"
        };
        private readonly List<Manager> TestManagers = new List<Manager>()
        {
            new Manager()
            {
                ID = "1",
                FName = "John",
                LName = "Deer",
                Email = "manager1@email.net",
                Password = "qqqqqq",
                BreweryID = "1"
            },

            new Manager()
            {
                ID = "2",
                FName = "Dwight",
                LName = "Schrute",
                Email = "manager2@email.net",
                Password = "qqqqqq",
                BreweryID = "2"
            }
        };

        private readonly List<Brewery> TestBreweries = new List<Brewery>()
        {
            new Brewery()
            {
                ID = "1",
                Name = "Lewis and Clark Brewery",
                State = "MT",
                City = "Helena",
                Address = "123 Beer Ave",
                Zip = "12345"
            },

            new Brewery()
            {
                ID = "2",
                Name = "Missouri River Brewing Co",
                State = "MT",
                City = "East Helena",
                Address = "123 Stout Ave",
                Zip = "12345"
            }
        };

        private readonly List<Beer> TestBeers = new List<Beer>()
        {
            new Beer()
            {
                ID = "2",
                BreweryID = "1",
                Name = "Vanilla Creamsickle",
                Type = "Ale",
                ABV = "9.5",
                IBU = "44",
                Keg = "100"
            },

            new Beer()
            {
                ID = "3",
                BreweryID = "1",
                Name = "Miners Gold",
                Type = "Stout",
                ABV = "9.5",
                IBU = "44",
                Keg = "100"
            }
        };

        private readonly List<Order> TestOrders = new List<Order>()
        {
            new Order()
            {
                ID = "2",
                CustomerID = "1",
                BeerId = "1",
                Date = DateTime.Now.ToString(),
                TableNumber = "1",
                BreweryId = "1",
                LineItemId = "1"
            },

            new Order()
            {
                ID = "3",
                CustomerID = "1",
                BeerId = "1",
                Date = DateTime.Now.ToString(),
                TableNumber = "1",
                BreweryId = "1",
                LineItemId = "1"
            }
        };
        

        private void Seed(BrewCrewContext testContext)
        {
            testContext.Managers.AddRange(TestManagers);
            testContext.Breweries.AddRange(TestBreweries);
            testContext.Beers.AddRange(TestBeers);
            testContext.Orders.AddRange(TestOrders);
            testContext.Beers.Add(TestBeer);
            testContext.Customers.Add(TestCustomer);
            testContext.SaveChanges();
        }

        [Fact]
        public void TestAddCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddCustomer").Options;
            using var testContext = new BrewCrewContext(options);
            repo = new DBRepo(testContext);

            //Act
            repo.AddCustomerAsync(TestCustomer);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Customers.SingleAsync(c => c.FName == TestCustomer.FName));
        }

        [Fact]
        public void TestAddManager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddManager").Options;
            using var testContext = new BrewCrewContext(options);
            repo = new DBRepo(testContext);

            //Act
            repo.AddManagerAsync(TestManager);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Managers.SingleAsync(c => c.FName == TestManager.FName));
        }

        [Fact]
        public void TestAddBrewery()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddBrewery").Options;
            using var testContext = new BrewCrewContext(options);
            repo = new DBRepo(testContext);

            //Act
            repo.AddBreweryAsync(TestBrewery);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Breweries.SingleAsync(c => c.Name == TestBrewery.Name));
        }

        [Fact]
        public void TestGetManagers()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetManagers").Options;
            using var testContext = new BrewCrewContext(options);
            
            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            repo = new DBRepo(assertContext);
            var result = repo.GetAllManagersAsync();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetBreweries()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetBreweries").Options;
            using var testContext = new BrewCrewContext(options);
            
            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            repo = new DBRepo(assertContext);
            var result = repo.GetAllBreweriesAsync();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetBeerById()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetBeerById").Options;
            using var testContext = new BrewCrewContext(options);
            
            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            repo = new DBRepo(assertContext);
            var result = repo.GetBeerByIdAsync("1");

            //Assert
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void TestGetAllBeersByBreweryId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetAllBeersByBreweryId").Options;
            using var testContext = new BrewCrewContext(options);
            
            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            repo = new DBRepo(assertContext);
            var result = repo.GetAllBeersByBreweryIdAsync("1");

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(3, result.Result.Count);
        }

        [Fact]
        public void TestPlaceOrder()
        {
               //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestPlaceOrder").Options;
            using var testContext = new BrewCrewContext(options);
            repo = new DBRepo(testContext);

            //Act
            repo.PlaceOrderAsync(TestOrder);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Orders.SingleAsync(c => c.ID == TestOrder.ID));

        }

        [Fact]
        public void TestGetAllOrdersByCustomerBreweryId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetAllOrdersByCustomerBreweryId").Options;
            using var testContext = new BrewCrewContext(options);
            
            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            repo = new DBRepo(assertContext);
            var result = repo.GetAllOrdersByCustomerBreweryIdAsync("1", "1");

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetUserByEmail()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetUserByEmail").Options;
            using var testContext = new BrewCrewContext(options);
            
            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            repo = new DBRepo(assertContext);
            var result = repo.GetUserByEmailAsync("customer1@email.net");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("customer1@email.net", result.Email);
        }
    }
}
