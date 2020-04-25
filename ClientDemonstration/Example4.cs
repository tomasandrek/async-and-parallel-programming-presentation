using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    public class Example4 : IDemonstrable
    {
        private static readonly HttpClient client = new HttpClient();

        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

        public async Task DemonstrateAsync()
        {
             Console.Write("Sending requests \n");

            var stringTask1 = client.GetStringAsync("http://localhost/api/DelayAsync/6000");
            var stringTask2 = client.GetStringAsync("http://localhost/api/DelayAsync/6000");
            var stringTask3 = client.GetStringAsync("http://localhost/api/DelayAsync/6000");

            var allTasks = new List<Task>{stringTask1, stringTask2, stringTask3};
            
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == stringTask1)
                {
                    Console.Write($"Request 1 response: {stringTask1.Result} \n");
                }
                else if (finished == stringTask2)
                {
                    Console.Write($"Request 2 response: {stringTask2.Result} \n");
                }
                else if (finished == stringTask3)
                {
                    Console.Write($"Request 3 response: {stringTask3.Result} \n");
                }
                allTasks.Remove(finished);
            }
        }

    }
}