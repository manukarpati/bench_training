using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurants.Ingredients;
using static Restaurants.Restaurant;

namespace Restaurants
{
    public class Chef
    {
        private HashSet<CookableIngredient> ThingsToPutInTheOven = new HashSet<CookableIngredient>();
        private string oventype = "";

        private List<Food> foodList;
        private List<Ingredient> ingredients;

        private bool isCookingInProcess = false;

        private const int ovenCapacity = 4;

        public async Task PlaceOrder(List<Food> foodList)
        {
            this.foodList = foodList;
            Stopwatch.Start();

            await Cook();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"[{Stopwatch.Elapsed}] Order completed on [{Thread.CurrentThread.ManagedThreadId}]");

        }

        private async Task Cook()
        {
            ingredients = foodList.SelectMany(f => f.ingredientList).OrderByDescending(i => i.NeedsCooking).ToList();


            while (foodList.Count > 0)
            {

                if (ingredients.Any(i => i.IsPrepared == false))
                {
                        await ingredients.FirstOrDefault(i => i.IsPrepared == false).Prepare();
                }

                if (ingredients.Any(i => i.IsReady == false && i.IsPrepared))
                {
                    PutInTheOven(ingredients.FirstOrDefault(i => i.IsReady == false && i.NeedsCooking));
                }

                if (ShouldIStartOven() && !isCookingInProcess)
                {
                    StartOven();
                }


                if (foodList.Any(i => i.IsReady))
                {
                   Serve(foodList.FirstOrDefault(i => i.IsReady));
                }
            }
        } 

        private void PutInTheOven(Ingredient i)
        {
            if (isCookingInProcess || i.IsReady)
            {
                return;
            }

            var ci = i as CookableIngredient;

            if (ThingsToPutInTheOven.Count == 0)
            {
                ThingsToPutInTheOven.Add(ci);
                ingredients.Remove(ci);
                oventype = ci.Name;
            }
            else
            {

                if (ThingsToPutInTheOven.Count < ovenCapacity && i.Name == oventype)
                {
                   ThingsToPutInTheOven.Add(ci);
                   ingredients.Remove(ci);
                   
                }
            }
        }

        private bool ShouldIStartOven()
        {
            bool shouldStart = false;

            if(ThingsToPutInTheOven.Count == ovenCapacity)
            {
                shouldStart = true;
            }
            else if(ThingsToPutInTheOven.Count == 0)
            {
                shouldStart = false;
            }
            else if (!ingredients.Any(i => i.IsReady == false && i.Name == oventype))
            {
                shouldStart = true;
            }

            return shouldStart;
        }

        private async void StartOven()
        {
            isCookingInProcess = true;
            await Restaurant.Oven.Fry(ThingsToPutInTheOven);
            ThingsToPutInTheOven.Clear();
            oventype = "";
            isCookingInProcess = false;

        }

        private void Serve(Food food)
        {
            foodList.Remove(food);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{Stopwatch.Elapsed}] {food.Name} served on [{Thread.CurrentThread.ManagedThreadId}]");

        }

    }
}
