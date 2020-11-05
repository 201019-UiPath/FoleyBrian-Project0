
using BrewCrewDB;
using BrewCrewDB.Models;
using BrewCrewLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagerUI.Menu
{
    public class ManagerOrderHistoryMenu: IMenuManager
    {
        private ManagerService managerService;
        public string BreweryID {get;set;}
        public string BreweryName {get;set;}
         private Dictionary<Order,Beer> data = new Dictionary<Order,Beer>();
        private  List<Order> orders;
        private readonly string[] options = {"Back", "Sort by Date", "Sort by ABV", "Sort by IBUs"};
        private string UserInput {get;set;}

        public ManagerOrderHistoryMenu(DBRepo repo) {
            this.managerService = new ManagerService(repo);
        }

        public void Start() {
            GetOrders();
            foreach(var option in data)
            {
                Order order = option.Key;
                Beer beer = option.Value;
                Console.WriteLine($"{order.Date} Name: {beer.Name} ABV: {beer.ABV}% IBUs: {beer.IBU}\n");
            }
            do{
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i}] - {options[i]}");
                }
                UserInput = Console.ReadLine();
                switch(UserInput)
                {
                    case "0":
                        break;
                        //sort by date
                    case "1":
                        SortByDate();
                        break;
                        //sort by ABV
                    case "2":
                        SortByABV();
                        break;
                        //sort by IBU
                    case "3":
                        SortByIBU();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

            }while(!(UserInput == "0"));
        }

        private void GetOrders() {
            orders = managerService.GetOrderHistoryByBreweryId(BreweryID);

            foreach(var order in orders)
            {
                foreach(var lineitem in order.LineItems)
                {
                     Beer beer = managerService.GetBeerById(lineitem.BeerID);
                     data[order] = beer;
                }
               
                
            }
        }

        private void SortByDate()
        {

            foreach(var option in data.OrderBy(k => k.Key.Date))
            {
            Beer beer = option.Value;
            Order order = option.Key;
            Console.WriteLine($"{order.Date} Name: {beer.Name} ABV: {beer.ABV}% IBUs: {beer.IBU}\n");
            }
        }

        private void SortByABV()
        {
             foreach(var option in data.OrderBy(k => k.Value.ABV))
            {
            Beer beer = option.Value;
            Order order = option.Key;
            Console.WriteLine($"{order.Date} Name: {beer.Name} ABV: {beer.ABV}% IBUs: {beer.IBU}\n");
            }
        }

        private void SortByIBU()
        {
             foreach(var option in data.OrderBy(k => k.Value.IBU))
            {
            Beer beer = option.Value;
            Order order = option.Key;
            Console.WriteLine($"{order.Date} Name: {beer.Name} ABV: {beer.ABV}% IBUs: {beer.IBU}\n");
            }
        }
    }
}