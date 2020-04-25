using System;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ef = new ExampleFactory();
            var example = ef.GetExample(3);

            //example.Demonstrate();
            await example.DemonstrateAsync();

        }
    }
}
