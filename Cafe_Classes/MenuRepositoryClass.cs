using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Classes
{
    public class MenuRepository : MenuClass
    {
        protected readonly List<MenuClass> _allMenuItems = new List<MenuClass>();
        //Add a new menu item
        public bool AddMenuItem(MenuClass newItem)
        {
            int startingCount = _allMenuItems.Count;
            _allMenuItems.Add(newItem);
            bool wasAdded = (_allMenuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Show  menu item by number
        public MenuClass GetMenuItemByNumber(int itemNumber)
        {
            foreach (MenuClass meal in _allMenuItems)
            {
                if (meal.MealNumber == itemNumber)
                {
                    return meal;
                }
            }
            return null;
        }
        //Get total count of menu items
        public int CountMenuItems()
        {
            int i = 0;
            foreach (MenuClass item in _allMenuItems)
            {
                i++;
            }
            return i;
        }
        //Show All list of all menu items
        public List<MenuClass> GetAllMenuItems()
        {
            return _allMenuItems;
        }
        //Get a list of all ingredients in a menu item
        public List<string> GetListOfIngredientsByItemNumber(int itemNumber)
        {
            foreach (MenuClass menuItem in _allMenuItems)
            {
                if (menuItem.MealNumber == itemNumber)
                {
                    return menuItem.MealIngredients;
                }
            }
            return null;
        }

        //Delete a menu item
        public bool DeleteMenuItem(MenuClass existingItem)
        {
            bool deleteResult = _allMenuItems.Remove(existingItem);
            return deleteResult;
        }

    }
}
