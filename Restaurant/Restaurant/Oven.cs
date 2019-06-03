using System;
using System.Collections.Generic;
using System.Text;
using Restaurants.Ingredients;
using System.Linq;
using System.Threading.Tasks;
using static Restaurants.Restaurant;
using System.Threading;

namespace Restaurants
{
    public class Oven
    {

        public async Task Fry<T>(HashSet<T> ingredientsInOven) where T: CookableIngredient
        {
                var ingredient = ingredientsInOven.First();


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{Stopwatch.Elapsed}] Frying started with {ingredientsInOven.Count} {ingredient.Name} on [{Thread.CurrentThread.ManagedThreadId}]");

                TimeSpan cookingTime = ingredientsInOven.First().CookTime;

                await Task.Delay(cookingTime);

                foreach (var i in ingredientsInOven)
                {
                    i.Cook();
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"[{Stopwatch.Elapsed}] Frying {ingredient.Name} finished on [{Thread.CurrentThread.ManagedThreadId}]");

        }
    }
}
