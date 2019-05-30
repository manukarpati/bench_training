using Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurants.Ingredients;
using Restaurant.Ingredients;

namespace Restaurant.Foods
{
    public class Hamburger : Food
    {
        private BurgerTypes type;

        public Hamburger(BurgerTypes type)
        {
            this.type = type;
            ingredientList = new List<Ingredient>() { new Patty(), new Ketchup() };
            Name = $"{type} Hamburger";


            switch (type)
            {
                case BurgerTypes.Basic:
                    ingredientList.Add(new Bun());
                    break;
                case BurgerTypes.Naked:
                    ingredientList.AddRange(new List<Ingredient>
                                            { new Lettuce(),
                                              new Tomato()});
                    break;
                case BurgerTypes.Cheese:
                    ingredientList.AddRange(new List<Ingredient>
                                            { new Bun(),
                                              new Cheese()});
                    break;
                case BurgerTypes.Full:
                    ingredientList.AddRange(new List<Ingredient>
                                            { new Bun(),
                                              new Lettuce(),
                                              new Tomato(),
                                              new Cheese()});
                    break;
                case BurgerTypes.Double:
                    ingredientList.AddRange(new List<Ingredient>
                                            { new Bun(),
                                              new Lettuce(),
                                              new Tomato(),
                                              new Cheese(),
                                              new Cheese(),
                                              new Patty()});
                    break;
                default:
                    throw new ArgumentException();
            }
        }

    }
}
