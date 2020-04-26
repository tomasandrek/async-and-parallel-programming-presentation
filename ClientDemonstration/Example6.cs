using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemonstration
{
    public class Example6 : IDemonstrable
    {
        private const int PreparationTime = 2000;

        public void Demonstrate()
        {
            throw new NotImplementedException();
        }

        public async Task DemonstrateAsync()
        {
            // Wrapping up synchronous methods into asynchronous.
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

        private Task ApplyJamAsync(Toast toast)
        {
            var task = Task.Run(() => {
                Thread.Sleep(PreparationTime);
            });

            return task;
        }

        private Task ApplyButterAsync(Toast toast)
        {
           var task = Task.Run(() => {
                Thread.Sleep(PreparationTime);
            });

            return task;
        }

        private Task<Toast> ToastBreadAsync()
        {
            var task = Task<Toast>.Run(() => {
                Thread.Sleep(PreparationTime);
                return new Toast();
            });

            return task;
        }

        private Task<Bacon> FryBaconAsync()
        {
              var task = Task<Bacon>.Run(() => {
                Thread.Sleep(PreparationTime);
                return new Bacon();
            });

            return task;
        }

        private Task<Egg> FryEggsAsync()
        {
              var task = Task<Egg>.Run(() => {
                Thread.Sleep(PreparationTime);
                return new Egg();
            });

            return task;
        }

        private Task<Coffee> PourCoffeeAsync()
        {
              var task = Task<Coffee>.Run(() => {
                Thread.Sleep(PreparationTime);
                return new Coffee();
            });

            return task;
        }
#endregion
    }
}