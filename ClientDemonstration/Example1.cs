using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    /// <summary>
    /// The difference between synchronous and asynchronous.
    /// </summary>
    public class Example1 : IDemonstrable
    {
        private const int PreparationTime = 2000;
        public void Demonstrate()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs();
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon();
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread();
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Console.WriteLine("Breakfast is ready!");
        }

        public async Task DemonstrateAsync()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = await FryEggsAsync();
            Console.WriteLine("eggs are ready");

            Bacon bacon = await FryBaconAsync();
            Console.WriteLine("bacon is ready");

            Toast toast = await ToastBreadAsync();
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            
            Console.WriteLine("Breakfast is ready!");
        }

#region Synchronous methods
        private void ApplyJam(Toast toast)
        {
            Thread.Sleep(PreparationTime);
        }

        private void ApplyButter(Toast toast)
        {
            Thread.Sleep(PreparationTime);
        }

        private Toast ToastBread()
        {
            Thread.Sleep(PreparationTime);
            return new Toast();
        }

        private Bacon FryBacon()
        {
            Thread.Sleep(PreparationTime);
            return new Bacon();
        }

        private Egg FryEggs()
        {
            Thread.Sleep(PreparationTime);
            return new Egg();
        }

        private Coffee PourCoffee()
        {
            Thread.Sleep(PreparationTime); // https://referencesource.microsoft.com/#mscorlib/system/threading/thread.cs,6a577476abf2f437 (721)
            return new Coffee();
        }
#endregion

#region Asynchronous methods

        private async Task ApplyJamAsync(Toast toast)
        {
            await Task.Delay(PreparationTime);
        }

        private async Task ApplyButterAsync(Toast toast)
        {
           await Task.Delay(PreparationTime);
        }

        private async Task<Toast> ToastBreadAsync()
        {
            await Task.Delay(PreparationTime);
            return new Toast();
        }

        private async Task<Bacon> FryBaconAsync()
        {
            await Task.Delay(PreparationTime);
            return new Bacon();
        }

        private async Task<Egg> FryEggsAsync()
        {
            await Task.Delay(PreparationTime); // https://referencesource.microsoft.com/#mscorlib/system/threading/Tasks/Task.cs,5fb80297e082b8d6 (5863)
            return new Egg();
        }

        private async Task<Coffee> PourCoffeeAsync()
        {
            await Task.Delay(PreparationTime);
            return new Coffee();
        }
#endregion

    }
}