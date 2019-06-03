using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Ingredients
{
    public class Bun : Ingredient
    {
        public Bun()
        {
            PrepTime = new TimeSpan(0, 0, 0, 0, 200);
            Name = "Bun";
        }
    }
}
