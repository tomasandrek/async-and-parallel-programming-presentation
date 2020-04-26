using System;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            var ef = new ExampleFactory();
            var example = ef.GetExample(22);

            example.Demonstrate();
            //await example.DemonstrateAsync();

        }
    }
}
