using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    /// <summary>
    /// Parallel.ForEach
    /// </summary>
    public class Example22 : IDemonstrable
    {
        private static readonly HttpClient client = new HttpClient();

        public void Demonstrate()
        {
            var delays = new List<int>(){300, 300, 500, 500, 500, 1000, 2000, 5000};
            var values = new ConcurrentBag<string>();

            Console.WriteLine("Starting sending requestes:");
            Parallel.ForEach(delays, (delay) =>
            {
                string response = client.GetStringAsync("http://localhost/api/DelayAsync/" + delay).Result;
                values.Add(response);
            });

            foreach(var value in values)
                Console.WriteLine(value);

        }

        public async Task DemonstrateAsync()
        {
            await Task.FromException(new NotImplementedException());
        }
    }
}