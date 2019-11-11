using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Stage1
{
    [TestFixture]
    public class MyComparableTest
    {
        [Test]
        public void Test1()
        {
            Random rand = new Random();
            List<Triangle> triangles = new List<Triangle>();

            for (int i = 0; i < 10; i++)
            {
                triangles.Add(new Triangle(i + rand.Next(1,10), i + rand.Next(2, 11)));
            }

            triangles.Sort();
            //var query = triangles.OrderByDescending(x => x.Square);

            foreach (var item in triangles)
            {
                Console.WriteLine(item.Square);
            }

        }

        private class Triangle : IComparable<Triangle>
        {
            public double Osnovanie { get; }
            public double Height { get; }
            public double Square { get; }

            public Triangle(double a, double h)
            {
                Osnovanie = a;
                Height = h;
                Square = (a * h) / 2;
            }

            public int CompareTo(Triangle triangle)
            {
                //return this.Square.CompareTo(triangle.Square);
                if (this.Square < triangle.Square)
                    return 1;
                if (this.Square > triangle.Square)
                    return -1;
                else
                    return 0;
            }
        }
    }
}