using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    public class Example5 : IDemonstrable
    {
        private static readonly HttpClient client = new HttpClient();

        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

        public async Task DemonstrateAsync()
        {
            await Task.Delay(1); // Fake - Due to public async Task...  

            // NEVER CALL .Result BEFORE AWAITING A METHOD!!! (TO MAKE IT METHOD SYNCHRONOUS)...
            Console.Write("Sending requests \n");
            var message = client.GetStringAsync("http://localhost/api/DelayAsync/6000").Result; //.Wait
            Console.WriteLine($"Response: {message}");

            // NEVER USE AN ASYNC KEYWORD TOGETHER WITH VOID TYPE
            
            
        }

    }
}