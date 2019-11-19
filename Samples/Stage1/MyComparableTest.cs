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

            triangles.Sort(new TriangleComparer());

            triangles.Sort();

        }

        private class Triangle : IComparable<Triangle>
        {
            public double Base { get; }
            public double Height { get; }
            public double Square { get; }

            public Triangle(double a, double h)
            {
                Base = a;
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

        private class TriangleComparer : IComparer<Triangle>
        {
            public int Compare(Triangle triangle1, Triangle triangle2)
            {
                //if (triangle1 == null)
                //    throw new NullReferenceException();
                //if (triangle2 == null)
                //    throw new NullReferenceException();


                if (Equals(triangle1?.Square, triangle2?.Square))
                    return 0;
                else if (triangle1?.Square > triangle2?.Square)
                    return 1;
                else
                    return -1;
            }
        }
    }
}