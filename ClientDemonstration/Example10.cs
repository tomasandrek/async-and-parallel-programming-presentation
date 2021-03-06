using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    /// <summary>
    /// Task continuation
    /// </summary>
    public class Example10 : IDemonstrable
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task DemonstrateAsync()
        {
            var task1 = GetResponse1();

            await task1.ContinueWith(t => {

                //t.Exception.InnerException.Message // Get an exception from task1
                var msg = SecondMethod();
                Console.WriteLine(msg);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);            
            
        }

        public async Task<string> GetResponse1()
        {
           return await client.GetStringAsync("http://localhost/api/DelayAsync/10");
        }

        public string SecondMethod()
        {
           return "SecondMethod executed";
        }

        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

    }
}