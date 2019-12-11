using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyThredingProject
{
    public class JobExecuter : IJobExecutor
    {
        public ConcurrentQueue<Action> _queue = new ConcurrentQueue<Action>();
        private readonly List<Action> _tasks = new List<Action>();
        public int Amount { get; }

        public JobExecuter(int amount)
        {
            Amount = amount;
        }

        public void Start(int maxConcurrent)
        {
            using (var semaphore = new Semaphore(1, maxConcurrent))
            {
                foreach (var item in _tasks)
                {
                    semaphore.WaitOne();

                    var task = Task.Run(() =>
                    {
                        //Thread.Sleep(1000);
                        _queue.Enqueue(item);
                    });

                    Console.WriteLine(task.Id);
                    semaphore.Release();
                }
            }
        }

        public void Stop()
        {
            foreach (var item in _queue)
            {
                item.Invoke();
            }
        }

        public void Add(Action action)
        {
            _tasks.Add(action);
        }

        public void Clear()
        {
        }
    }
}