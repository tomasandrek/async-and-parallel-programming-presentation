using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    /// <summary>
    /// Progress reporting
    /// </summary>
    public class Example12 : IDemonstrable
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task DemonstrateAsync()
        {
            await GetResponses(new Progress<int>(percent => Console.WriteLine(percent + "% done.")));
        }

        public Task<List<string>> GetResponses(IProgress<int> progress)
        {
            var responsesTask = Task.Run(async() =>
            {
                var responses = new List<string>();

                for(int i=0;i<10;i++)
                {
                    await Task.Delay(1000);
                    string response = await client.GetStringAsync("http://localhost/api/DelayAsync/10");
                    Console.WriteLine($"Response {i}: {response}");
                    responses.Add(response);

                    if (progress != null)
                    {
                        progress.Report(((i + 1) * 100 / 10));
                    }
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