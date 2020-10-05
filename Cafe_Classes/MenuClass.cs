using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Classes
{
    public class MenuClass
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDesc { get; set; }
        public decimal MealPrice { get; set; }
        public List<string> MealIngredients { get; set; } = new List<string>();
        public MenuClass(int mealNumber, string mealName, string mealDescription, decimal mealPrice, List<string> ingredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDesc = mealDescription;
            MealPrice = mealPrice;
            MealIngredients = ingredients;
        }
        public MenuClass() { }
    }
}
