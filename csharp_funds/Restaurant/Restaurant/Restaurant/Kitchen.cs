using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public class Kitchen
    {
        private IFood AddExtras(IFood mainFood, IEnumerable<string> extras)
        {
           IFood fullFood = mainFood;
           foreach(var e in extras)
            {
                if (e == nameof(Ketchup))
                {
                    fullFood = new Ketchup(fullFood);
                }
                else if (e == nameof(Mustard))
                {
                    fullFood = new Mustard(fullFood);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return fullFood;
        }

        private IFood CreateMainFood(string food)
        {
            if (food == nameof(Chips))
            {
                return new Chips();
            }
            else if (food == nameof(HotDog))
            {
                return new HotDog();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        internal IFood Cook(Order order)
        {
            IFood food = CreateMainFood(order.Food);
            if(order.Extras != null)
            {
                food = AddExtras(food, order.Extras);
            }

            return food;
        }
    }
}
