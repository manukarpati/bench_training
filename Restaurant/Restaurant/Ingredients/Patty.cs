using Restaurants.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Ingredients
{
    public class Patty : CookableIngredient { 


        public Patty()
        {
            NeedsCooking = true;
            PrepTime = new TimeSpan(0, 0, 0, 0, 100);
            CookTime = new TimeSpan(0, 0, 0, 0, 1000);
            Name = "Patty";

        }

    }
}
