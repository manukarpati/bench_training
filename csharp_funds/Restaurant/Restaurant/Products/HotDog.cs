using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public class HotDog :Food
    {
        public override double CalculateHappiness(double happiness)
        {
            return happiness + 2;
        }

    }
}
