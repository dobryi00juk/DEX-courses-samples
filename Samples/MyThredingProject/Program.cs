using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyThredingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new JobExecuter(10);
            Random r = new Random();

            for (int i = 0; i < executor.Amount; i++)
            {
                executor.Add(() =>
                {
                    Console.WriteLine($"Current time {DateTime.Now}");
                    Thread.Sleep(r.Next(200, 1000));
                });
            }

            executor.Start(3);
            executor.Stop();
            Task.WaitAll();
            Console.WriteLine("Main thread exits");
        }
    }
}