using Restaurants.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Ingredients
{
    public class Tomato
   : Ingredient
    {
        public Tomato()
        {
            NeedsCooking = false;
            PrepTime = new TimeSpan(0, 0, 0, 0, 200);
            Name = "Tomato";

        }

    }
}
