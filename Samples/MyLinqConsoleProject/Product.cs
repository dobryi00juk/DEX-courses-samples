using System;
using System.Collections.Generic;
using System.Text;

namespace MyLinqConsoleProject
{
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
}
