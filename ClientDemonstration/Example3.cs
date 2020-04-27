using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    /// <summary>
    /// Checking if everything has been done. Task.WhenAll(
    /// </summary>
    public class Example3 : IDemonstrable
    {
        private const int PreparationTime = 6000;

        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

        public async Task DemonstrateAsync()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            // Start tasks and dring a coffee
            Task<Egg> eggsTask = FryEggsAsync();
            Task<Bacon> baconTask = FryBaconAsync();
            Task<Toast> toastTask = ToastBreadAsync();
            Console.WriteLine("All tasks have been started. Now go and drink coffee.");

            await Task.WhenAll(eggsTask, baconTask, toastTask);
            Console.WriteLine("Everything is ready just apply butter and jam on the toast");
            
            ApplyButter(toastTask.Result);
            ApplyJam(toastTask.Result);
            
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