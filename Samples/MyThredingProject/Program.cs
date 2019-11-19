using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyThredingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobs = new JobExecuter(10);
            jobs.Start(15);
        }
        
    }

    interface IJobExecuter
    {
        int Amount { get; }
        void Start(int maxConcurrent);
        void Stop();
        void Add(Action action);
        void Clear();
    }

    class JobExecuter : IJobExecuter
    {
        public int Amount { get; }
        public JobExecuter(int amount)
        {
            Amount = amount;
        }

        public void Start(int maxConcurrent)
        {
            var messages = new List<string>()
            {
                "message 1",
                "message 2",
                "message 3",
                "message 4",
                "message 5",
                "message 6"
            };

            using (SemaphoreSlim semaphore = new SemaphoreSlim(Amount, maxConcurrent))
            {
                Queue<Task> tasks = new Queue<Task>();

                foreach (var item in messages)
                {
                    semaphore.Wait();
                    var t = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            Process(item);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    //tasks.Add(t);
                }
            }

            Console.ReadKey();
        }

        public void Stop() { }

        public void Add(Action action)
        {
        }
        public void Clear()
        {
            Console.WriteLine();
        }

        public static void Process(string msg)
        {
            Thread.Sleep(2000);
            Console.WriteLine(msg);
            var _ts = new BlockingCollection<Action>(); 
        }
    }

}
