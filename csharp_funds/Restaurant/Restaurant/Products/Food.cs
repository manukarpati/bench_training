using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public abstract class Food : IFood
    {
        protected Food()
        {
        }

        public double CalculateHappiness(double happiness)
        {
            throw new NotImplementedException();
        }
    }
}
