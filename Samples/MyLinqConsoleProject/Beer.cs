using System;
using System.Collections.Generic;
using System.Text;

namespace MyLinqConsoleProject
{
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
