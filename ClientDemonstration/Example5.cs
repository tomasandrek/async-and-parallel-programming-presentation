using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    /// <summary>
    /// Bad practices.
    /// </summary>
    public class Example5 : IDemonstrable
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task DemonstrateAsync()
        {
            await Task.Delay(1); // Fake - Due to public async Task...  

            // NEVER CALL .Result or .Wait BEFORE AWAITING A METHOD!!! (TO MAKE A METHOD SYNCHRONOUS)...
            Console.Write("Sending requests \n");
            var message = client.GetStringAsync("http://localhost/api/DelayAsync/1000").Result; //.Wait
            Console.WriteLine($"Response: {message} \n");

            // NEVER USE AN ASYNC KEYWORD TOGETHER WITH VOID TYPE. THIS DOES NOT GO FOR EVENT HANDLERS.
            try
            {
                await Divide(10,0);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception has been handled. Error: " + ex.Message);
            }     
        }

        public async Task Divide(int operand1, int operand2)
        {
            double result = await Task<double>.Run(() => (operand1 / operand2));
            Console.WriteLine("Result: " + result);
        }
        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

    }
}