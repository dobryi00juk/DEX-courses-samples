using System;
using NUnit.Framework;

namespace Stage1
{
    [TestFixture]
    public class MyOopTest
    {
        [Test]
        public void Test1()
        {
            var buildings = new Building[]
            {
                new Building(1000, 4),
                new House(2000, 8, 49, true),
                new Office(3000, 12, 80)
            };
            
            foreach (var item in buildings)
            {
                item.ShowInfo();
            }
        }

        class Building
        {
            public int Area { get; set; }
            public int Floors { get; set; }

            public Building(int area, int floors)
            {
                this.Area = area;
                this.Floors = floors;
            }

            public virtual void ShowInfo()
            {
                Console.WriteLine("Тупо здание!)");
                Console.WriteLine();
            }
        }

        class House : Building
        {
            private bool HaveLift { get; set; }
            public int Occupants { get; set; }

            public House(int area, int floors, int occupants, bool lift) : base(area, floors)
            {
                this.Occupants = occupants;
                this.HaveLift = lift;
            }

            public override void ShowInfo()
            {
                Console.WriteLine("Дом имеет " + Floors + " этажей и " + Occupants + " жителей!");
                Console.WriteLine();

                if (HaveLift)
                    Console.WriteLine("Есть лифт");
                else
                    Console.WriteLine("Нет лифта!");
            }

            public void MaxOccupant(int minArea)
            {
                Console.WriteLine("Максимальное количество жителей, если минимальная площадь на человека  {0} м : {1} чел ", minArea, Area / minArea);
                Console.WriteLine();
            }
        }

        class Office : Building
        {
            public int Offices { get; set; }
            public Office(int area, int floors, int offices) : base(area, floors)
            {
                this.Offices = offices;
            }

            public override void ShowInfo()
            {
                Console.WriteLine("Офис имеет " + Floors + " этажей и " + Offices + " офисов!");
                Console.WriteLine();
            }
        }
    }
}