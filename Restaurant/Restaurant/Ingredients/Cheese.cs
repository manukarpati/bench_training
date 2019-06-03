using Restaurants.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Ingredients
{
    public class Cheese
   : Ingredient
    {
        public Cheese()
        {
            PrepTime = new TimeSpan(0);
            Name = "Cheese";

        }

    }
}
