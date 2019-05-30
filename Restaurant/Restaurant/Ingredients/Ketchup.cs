using Restaurants.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Ingredients
{
    public class Ketchup
       : Ingredient
    {
        public Ketchup()
        {
            NeedsCooking = false;
            PrepTime = new TimeSpan(0);
            Name = "Ketchup";

        }

    }
}
