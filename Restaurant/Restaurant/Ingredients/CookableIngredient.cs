using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Ingredients
{
   public abstract class CookableIngredient :Ingredient 
    {
        public TimeSpan CookTime { get; protected set; }

        public void Cook()
        {
            if (this.IsPrepared)
            {
                IsReady = true;
            }
        }

    }
}
