using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Stage1
{
    [TestFixture]
    public class MyRegularExpressionTests
    {
        [Test]
        public void Regex_IsMatch_ReturnTrue()
        {
            string value = "1, 1000, 1 000 000, 100.23";
            string pattern1 = @"^\d{1}";
            string pattern2 = @"\d{4}";
            string pattern3 = @"\d{1}\s{1}\d{3}\s{1}\d{3}";
            string pattern4 = @"\d{3}\.*\d{2}";
            
            var result1 = Regex.Match(value, pattern1);
            var result2 = Regex.Match(value, pattern2);
            var result3 = Regex.Match(value, pattern3);
            var result4 = Regex.Match(value, pattern4);
            
            bool isMatch1 = Regex.IsMatch(value, pattern1);
            bool isMatch2 = Regex.IsMatch(value, pattern2);
            bool isMatch3 = Regex.IsMatch(value, pattern3);
            bool isMatch4 = Regex.IsMatch(value, pattern4);
            
            Assert.IsTrue(isMatch1);
            Assert.IsTrue(isMatch2);
            Assert.IsTrue(isMatch3);
            Assert.IsTrue(isMatch4);
        }

        [Test]
        public void Regex_IsMatch_String()
        {
            string input = "http://ya.ru/api?r=1&x=23";
            string value = @"(?<==)\w*";
            string key = @"\w(?==)";

            var keys = Regex.Matches(input, key);
            var values = Regex.Matches(input, value);
            
            var dict = new Dictionary<string, string>();

            for (int i = 0; i < keys.Count; i++)
            {
                dict.Add(keys[i].ToString(), values[i].ToString());
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"key: {item.Key} value: {item.Value}");
            }
        }

        [Test]
        public void Regex_Matches_Test()
        {
            string value = "+373 77767852, 77867852, 0(777) 86852 9999999999999 54 54 11111";
            var pattern = @"77[7,8]\d{5}";
            var result = Regex.Matches(value, pattern);

            foreach (var item in result)
            {
                Console.WriteLine(item);    
            }
        }

        [Test]
        public void Regex_Replace_Test()
        {
            var input = "etst    stst s tsst s   st st st  ";
            var pattern = @"\s+";
            var replacement = " ";
            var result = Regex.Replace(input, pattern, replacement);
            
            Console.WriteLine(result);
        }
    }
}