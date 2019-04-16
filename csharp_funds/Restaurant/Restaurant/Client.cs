using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public class Client
    {
        public Double Happiness { get; set; }
        public string Name { get; }
        public Client (string name, double happiness)
        {
            this.Name = name;
            this.Happiness = happiness;
        }

        public void Eat(IFood food)
        {
            Happiness = food.CalculateHappiness(this.Happiness);
        }
    }
}
