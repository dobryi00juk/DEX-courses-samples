using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Stage1
{
    public class MyListTests
    {
        [Test]
        public void Test()
        {
            Object one = new Object();
            Object two = new Object();

            List<Object> collection1 = new List<Object>() { one, two };

            Console.WriteLine(collection1.Capacity);
            collection1.Remove(one);

            Object tree = new Object();
            Object four = new Object();

            List<Object> collection2 = new List<Object>() { tree, four };

            foreach (var item in collection2)
            {
                collection1.Add(item);
            };

            if (collection2.Contains(tree)) Console.WriteLine("Good");
        }

        public class Object
        {
            public int A { get; set; }
            public int B { get; set; }
        }
    }
}