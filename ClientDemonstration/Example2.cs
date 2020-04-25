using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    public class Example2 : IDemonstrable
    {
        private const int PreparationTime = 2000;

        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

        public async Task DemonstrateAsync()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            // Start tasks and go ahead
            Task<Egg> eggsTask = FryEggsAsync();
            Task<Bacon> baconTask = FryBaconAsync();

            // Start task 'toast' and wait until it finishes
            Toast toast = await ToastBreadAsync();
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            // Wait for tasks 'eggs' and 'bacon' to be finished
            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            
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
            Thread.Sleep(PreparationTime);
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
            await Task.Delay(PreparationTime);
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