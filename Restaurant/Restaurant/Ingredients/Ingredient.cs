using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Restaurants.Restaurant;

namespace Restaurants.Ingredients
{
    public abstract class Ingredient
    {
        public bool NeedsCooking => this is CookableIngredient;
        public TimeSpan PrepTime { get; protected set; }
        public string Name { get; protected set; }

        public bool IsReady { get; set; }
        public bool IsPrepared { get; set; }

        public async Task Prepare()
        {
            await Task.Delay(PrepTime);
            IsPrepared = true;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{Stopwatch.Elapsed}] {this.Name} prepared on [{Thread.CurrentThread.ManagedThreadId}]");

            if (!NeedsCooking)
            {
                IsReady = true;
            }
        }
    }
}
