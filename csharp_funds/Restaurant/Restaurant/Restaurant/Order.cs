using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public class Order
    {
        public IEnumerable<string> Extras { get; }
        public string Food { get; }

        public Order(string food, IEnumerable<string> extras)
        {
            this.Food = food;
            this.Extras = extras;
        }

        public void NotifyReady(IFood food)
        {
            //TODO
        }
        public event EventHandler<FoodReadyEventArgs> FoodReady;
    }
}
