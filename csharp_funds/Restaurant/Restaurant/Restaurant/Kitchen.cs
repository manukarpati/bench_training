using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public class Kitchen
    {
        private IFood AddExtras(IFood mainFood, IEnumerable<string> extras)
        {
            //TODO
            return mainFood;
        }

        private IFood CreateMainFood(string food)
        {
            //TODO
            return new Chips();
        }

        internal IFood Cook(Order order)
        {
            //create an actual food from the order
            IFood food = CreateMainFood(order.Food);
            if(order.Extras != null)
            {
                food = AddExtras(food, order.Extras);
            }

            return food;
        }
    }
}
