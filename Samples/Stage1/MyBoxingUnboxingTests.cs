using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace Stage1
{
    [TestFixture]
    public class MyBoxingUnboxingTests
    {
        [Test]
        public void BoxingTest()
        {
            List<object> list = new List<object>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i);
            }

            stopwatch.Stop();
            var result = stopwatch.Elapsed;

            Console.WriteLine(result.ToString());
        }

        [Test]
        public void UnboxingTest()
        {
            List<object> objects = new List<object>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
            List<int> list = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var item in objects)
            {
                list.Add((int) item);
            }

            stopwatch.Stop();
            var result = stopwatch.Elapsed;

            Console.WriteLine(result.ToString());
        }

        [Test]
        public void Unboxing_ThrowInvalidCastException_Test()
        {
            int i = 123;
            object o = i; //упаковка

            Assert.Throws<InvalidCastException>(() =>
            {
                int s = (short)o; //попытка распаковки
            });
        }
    }
}