using Restaurant.Ingredients;
using Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Foods
{
    public class Frieses :Food
    {
        public Frieses(bool withKetchup = false)
        {
            ingredientList.Add(new Fries());
            Name = "Fries";

            if (withKetchup)
            {
                ingredientList.Add(new Ketchup());
                Name = "Fries with ketchup";

            }
        }

    }
}
