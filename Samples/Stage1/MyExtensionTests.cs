using System;
using NUnit.Framework;

namespace Stage1
{
    [TestFixture]
    public class MyExtensionTests
    {
        [Test]
        public void StringExtensionsTests()
        {
            var date = new DateTime(1991, 9, 15);
            var interval = date - 5.IntExtention();
            Console.WriteLine(interval);
        }
    }

    public static class IntExtensions
    {
        public static TimeSpan IntExtention(this int number)
        {
            return TimeSpan.FromDays(number);
        }
    }
}