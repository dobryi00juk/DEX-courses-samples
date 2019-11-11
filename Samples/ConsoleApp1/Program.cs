using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine($"value: {i*0.0623}");
            }
        }
    }
}
