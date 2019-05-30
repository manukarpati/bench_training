using Restaurants.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Ingredients
{

    public class Fries : CookableIngredient
    {

        public Fries()
        {
            NeedsCooking = true;
            PrepTime = new TimeSpan(0, 0, 0, 0, 100);
            CookTime = new TimeSpan(0, 0, 0, 0, 2000);
            Name = "Fries";

        }



    }
}
