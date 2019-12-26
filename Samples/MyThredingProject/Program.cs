using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyThredingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new JobExecuter(20);
            var r = new Random();

            ThreadPool.GetMaxThreads(out var nWorkerThreads, out var nCompletionThreads);
            Console.WriteLine("Максимальное количество потоков: " + nWorkerThreads
                                                                  + "\nПотоков ввода-вывода доступно: " + nCompletionThreads);
            
            try
            {
                for (var i = 0; i < 50; i++)
                {
                    //if (i >= executor.Amount) break;

                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        executor.Add(() =>
                        {
                            Console.WriteLine("Thread ID : {0}", Thread.CurrentThread.ManagedThreadId);
                        });
                    });
                }
                Thread.Sleep(1000);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                executor.Start(4);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            executor.Stop();

            executor.Add(() => Console.WriteLine("Action 1"));
            executor.Add(() => Console.WriteLine("Action 2"));
            executor.Add(() => Console.WriteLine("Action 3"));
            executor.Add(() => Console.WriteLine("Action 4"));
            executor.Add(() => Console.WriteLine("Action 5"));
            
            executor.Start(3);
            
            executor.Clear();
            executor.Start(3);
            //Thread.Sleep(5000);
        }
    }
}