using WNWN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WNWN.Data
{
    public class IngredientsData
    {
        static private Dictionary<int, Ingredients> Ingredient = new Dictionary<int, Ingredients>();

        public static IEnumerable<Ingredients> GetAll()
        {
            return Ingredient.Values;
        }

        public static void Add(Ingredients newIngredients)
        {
            Ingredient.Add(newIngredients.Id, newIngredients);
        }

        public static void Remove(int id)
        {
            Ingredient.Remove(id);
        }

        public static Ingredients GetById(int id)
        {
            return Ingredient[id];
        }
    }
}
