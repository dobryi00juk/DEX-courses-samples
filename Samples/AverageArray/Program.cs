using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AverageArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ulong sum1 = 0;
            ulong sum2 = 0;
            var arr = Enumerable.Range(1, 100 * 1000 * 1000).ToArray();//.AsParallel().Sum();
            
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Parallel.ForEach(arr, i =>
            {
                lock (arr)
                {
                    sum1 += (ulong)i;
                }
            });

            //Parallel.For(0, arr.Length, i =>
            //{
            //    lock (arr)
            //    {
            //        sum1 += (ulong)i;
            //    }
            //});

            watch.Stop();
            double[] arr3 = new double[100 * 1000 * 1000];
            
            ///////////
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = arr3[i] + 0.00001;
            }

            var summa = arr3.AsParallel().Sum();
            ///////////
            


            var average1 = sum1 / (ulong) arr.Length;

            Console.WriteLine("Elapsed time " + watch.Elapsed);
            Console.WriteLine("Average parallel " + average1);

            Console.WriteLine("--------------------");

            var arr2 = Enumerable.Range(1, 100 * 1000 * 1000).ToArray();

            watch.Start();

            foreach (var item in arr2)
            {
                sum2 += (ulong)item;
            }

            watch.Stop();
            var average2 = sum2 / (ulong)arr2.Length;

            Console.WriteLine(watch.Elapsed);
            Console.WriteLine("Average one thread " + average2);
        }
    }
}