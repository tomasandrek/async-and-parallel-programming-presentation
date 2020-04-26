using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    public class Example20 : IDemonstrable
    {
        static readonly object _object = new object();  
  
        public void Demonstrate()
        {
            for (int i = 0; i < 10; i++)  
            {  
                ThreadStart start = new ThreadStart(TestLock);
                Thread thread = new Thread(start);
                thread.Name = $"Thread {i}";
                thread.Start(); 
            }  
  
            Console.ReadLine(); 
        }

        private void TestLock()  
        {         
            lock (_object)  
            {  
                Thread.Sleep(1000);  
                Console.WriteLine(Thread.CurrentThread.Name + " " + DateTime.Now);  
            }  
        }  

        public async Task DemonstrateAsync()
        {
            // Reporting progress
            throw new NotImplementedException();
        }
    }
}