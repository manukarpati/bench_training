using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public abstract class Extra : IFood
    {
        protected IFood Food { get; set; }

        internal Extra (IFood food)
        {
            Food = food;
        }

        public double CalculateHappiness(double happiness)
        {
            throw new NotImplementedException();
        }
    }
}
