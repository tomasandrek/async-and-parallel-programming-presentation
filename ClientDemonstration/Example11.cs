using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    public class Example11 : IDemonstrable
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly CancellationTokenSource canToken = new CancellationTokenSource();

        public async Task DemonstrateAsync()
        {
            // Task continuation
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Cancel event triggered");
                canToken.Cancel();
                eventArgs.Cancel = true;
            };

            await GetResponses(canToken.Token);
         
            Console.ReadLine();
        }

        public Task<List<string>> GetResponses(CancellationToken cancellationToken)
        {
            var responsesTask = Task.Run(async() =>
            {
                var responses = new List<string>();

                for(int i=0;i<10;i++)
                {
                    if(cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Canceling the operation.");
                        return responses;
                    }

                    await Task.Delay(1000);
                    string response = await client.GetStringAsync("http://localhost/api/DelayAsync/10");
                    Console.WriteLine($"Response {i}: {response}");
                    responses.Add(response);
                }

                return responses;
            });

          return responsesTask;
        }

        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

    }
}