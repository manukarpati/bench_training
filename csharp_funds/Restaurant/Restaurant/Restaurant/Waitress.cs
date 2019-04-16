using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public class Waitress
    {
        private Queue<Order> orders;

        private Kitchen Kitchen { get; set; }

        public Waitress(Kitchen kitchen)
        {
            this.Kitchen = kitchen;
            orders = new Queue<Order>();
        }

        public void TakeOrder(Client client, Order order)
        {
            orders.Enqueue(order);
        }
    }
}
