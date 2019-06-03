using Restaurant.Foods;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Restaurants.Restaurant;

namespace Restaurants
{
    class Program
    {


        async static Task Main(string[] args)
        {
            var orderList = new List<Food>()
            {
                new Frieses(),
                new Frieses(),
                new Frieses(),
                new Frieses(true),
                new Frieses(true),
                new Frieses(true),
                new Frieses(true),
                new Hamburger(BurgerTypes.Basic),
                new Hamburger(BurgerTypes.Basic),
                new Hamburger(BurgerTypes.Cheese),
                new Hamburger(BurgerTypes.Cheese),
                new Hamburger(BurgerTypes.Double),
                new Hamburger(BurgerTypes.Double),
                new Hamburger(BurgerTypes.Full),
                new Hamburger(BurgerTypes.Full),

            };
            Console.WriteLine($"[{Stopwatch.Elapsed}] Ordering started on [{Thread.CurrentThread.ManagedThreadId}]");


            Chef gordon = new Chef();
            await gordon.PlaceOrder(orderList);



            Console.WriteLine($"Customers are happy on [{Thread.CurrentThread.ManagedThreadId}]");
        }
    }
}
