using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace MyLinqConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            var date = DateTime.Now.AddDays(-50);
            List<Beer> beers = new List<Beer>();

            for (int i = 1; i <= 100; i++)//add aphrodisiacs to list
            {
                beers.Add(new Beer(i, rand.Next(10, 50), "Bavaria",date.AddMonths(rand.Next(-3, 4)), 30));
            }
            var query1 = beers.Where(x => x.Price < 40).GroupBy(x =>x.Expired).OrderBy(x=>x.Key);

            foreach (IGrouping<bool, Beer> item in query1)
            {
                Console.WriteLine($"Expired: {item.Key}");
                foreach (var i in item)
                    Console.WriteLine($"Production time: {i.ProductionTime} | Expiration time: {i.ProductionTime.AddDays(i.ExpirationTime)}");
            }

            Console.WriteLine();

            var maxPrice = beers.Max(x => x.Price);
            var minPrice = beers.Min(x => x.Price);
            var sum = beers.Sum(x => x.Price);
            var any = beers.Any(x => x.ProductionTime < DateTime.Now);
            var all = beers.All(x => x.Price > 35);

            Console.WriteLine($"Min price: {minPrice} | Max price: {maxPrice} | Sum: {sum} | Any: {any}");
            Console.WriteLine(all);
            Console.ReadKey();
        }
    }

    internal abstract class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }

        protected Product(int id, int price, string name)
        {
            Id = id;
            Price = price;
            Name = name;
        }
    }

    internal class Beer : Product
    {
        public DateTime ProductionTime { get; set; }
        public int ExpirationTime { get; set; }//days
        public bool Expired { get; set; }

        public Beer(int id, int price, string name, DateTime productionTime, int expirationTime) : base(id, price, name)
        {
            ProductionTime = productionTime;
            ExpirationTime = expirationTime;

            Expired = productionTime.AddDays(expirationTime) < DateTime.Now ? true : false;
        }
    }
}