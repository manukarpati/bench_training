using Restaurants.Ingredients;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants
{
    public abstract class Food
    {
        public string Name;

        public List<Ingredient> ingredientList = new List<Ingredient>();

        public bool IsReady => ingredientList !=null ?  ingredientList.All(i => i.IsReady) : false;
    }
}