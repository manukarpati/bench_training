using Restaurant.Foods;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            Chef gordon = new Chef();
            await gordon.PlaceOrder(orderList);



            Console.WriteLine("Hello World!");
        }
    }
}
