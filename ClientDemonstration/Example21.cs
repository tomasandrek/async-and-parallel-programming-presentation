using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    /// <summary>
    /// Deadlocks
    /// </summary>
    public class Example21 : IDemonstrable
    {
        public void Demonstrate()
        {
            // Simulation of a deadlock.
            object lock1 = new object();
            object lock2 = new object();

            Console.WriteLine("Starting...");

            var task1 = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        Console.WriteLine("Finished Thread 1");
                    }
                }
            });
        
            var task2 = Task.Run(() =>
            {
                lock (lock2)
                {
                    Thread.Sleep(1000);
                    lock (lock1)
                    {
                        Console.WriteLine("Finished Thread 2");
                    }
                }
            });
        
            Task.WaitAll(task1, task2);
            Console.WriteLine("Finished...");
        }

        public async Task DemonstrateAsync()
        {
           await Task.FromException(new NotImplementedException());
        }

    }
}