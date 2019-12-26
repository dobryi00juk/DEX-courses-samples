using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MyThredingProject
{
    public class JobExecuter : IJobExecutor
    {
        private ConcurrentQueue<Action> _queue = new ConcurrentQueue<Action>();
        private volatile bool _stop;
//        private SemaphoreSlim _semaphoreSlim;
        public int Amount { get; }

        public JobExecuter(int amount)
        {
            Amount = amount;
        }

        public void Start(int maxConcurrent)
        {
            if (maxConcurrent < 0) throw new ArgumentOutOfRangeException(nameof(maxConcurrent));

            _stop = false;
            //_semaphoreSlim = new SemaphoreSlim( maxConcurrent);
            
            while (!_stop)
            {
                if (_queue.IsEmpty)
                {
                    _stop = true;
                    break;
                }
                
                Parallel.For(0, 2, i =>
                {
                    _queue.TryDequeue(out var item);
                    item?.Invoke();
                    Thread.Sleep(1000);
                });

                /*_semaphoreSlim.Wait();
                
                Task.Run(() =>
                {
                    _queue.TryDequeue(out var item);
                    item?.Invoke();
                    Thread.Sleep(1000);
                    _semaphoreSlim.Release();
                })*/;

            }

            Task.WaitAll();
        }

        public void Stop()
        {
            _stop = true;
        }

        public void Add(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            if (_queue.Count >= Amount) return;

            _queue.Enqueue(action);
            Console.WriteLine("{0} was added!", action.Method.MemberType);
        }

        public void Clear()
        {
            _queue = new ConcurrentQueue<Action>();
        }

        public int ShowCount()
        {
            return _queue.Count;
        }
    }
}