
using System;
using Cafe_Console;
using Cafe_Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console.UI
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepository = new MenuRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool contRun = true;
            while (contRun)
            {
                Console.Clear();
                Console.WriteLine("Please choose an option between 1-4\n" +
                    "1) Show All Menu Items\n" +
                    "2) Add an Item To Menu\n" +
                    "3) Delete an Item From Menu\n" +
                    "4) Exit");
                string UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "1":
                        //Show all items
                        ShowAllMenu();
                        break;
                    case "2":
                        //Add items
                        AddMenuItem();
                        break;
                    case "3":
                        //RemoveMenuItem an item
                        RemoveMenuItem();
                        break;
                    case "4":
                        //Exit
                        contRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                            "Press any key to continue........"); ;
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void ShowAllMenu()
        {
            Console.Clear();
            List<MenuClass> allMenuItems = _menuRepository.GetAllMenuItems();
            foreach (MenuClass item in allMenuItems)
            {
                DisplayMenu(item);
                DisplayIngredients(item, item.MealNumber);
                Console.WriteLine("-------------");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        private void AddMenuItem()
        {
            int count = _menuRepository.CountMenuItems();
            int newMealNumber = count + 1;
            Console.Clear();
            Console.WriteLine($"There are currently {count} Meals on the menu. This will be Meal #{newMealNumber}.\n" +
                $"Please enter the name of this Meal:");
            MenuClass meal = new MenuClass();
            meal.MealNumber = newMealNumber;
            meal.MealName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Next, please enter a description of the meal:");
            meal.MealDesc = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please set the price for this meal:");
            string input = Console.ReadLine();
            decimal value = decimal.Parse(Console.ReadLine());
            meal.MealPrice = value;
            Console.WriteLine();
            Console.WriteLine("Please enter the ingredients of this meal:");
            List<string> userIngredients = new List<string>();
            bool isAddingIngredients = true;
            while (isAddingIngredients)
            {
                var userInput = Console.ReadLine();
                userIngredients.Add(userInput);
                Console.WriteLine("Would you like to add another ingredient? Y/N");
                string response = Console.ReadLine();
                //Account for user input variations
                string r = response.ToLower();
                if (r == "y" || r == "yes")
                {
                    isAddingIngredients = true;
                }
                else
                {
                    isAddingIngredients = false;
                }
                meal.MealIngredients = userIngredients;
            }
            _menuRepository.AddMenuItem(meal);
            Console.WriteLine($"{meal.MealName} has been added to the menu.");
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        private void RemoveMenuItem()
        {
            Console.WriteLine("Which item would you like to remove?");
            List<MenuClass> menuList = _menuRepository.GetAllMenuItems();
            foreach (var item in menuList)
            {
                Console.WriteLine($"#{item.MealNumber} - The {item.MealName}");
            }
            int targetItem = int.Parse(Console.ReadLine());
            int correctIndex = targetItem - 1;
            if (correctIndex >= 0 && correctIndex < menuList.Count)
            {
                MenuClass selection = menuList[correctIndex];
                if (_menuRepository.DeleteMenuItem(selection))
                {
                    Console.WriteLine($"{selection.MealName} has been removed from the menu.");
                }
                else
                {
                    Console.WriteLine("You did not select a valid option.");
                }
            }
            else
            {
                Console.WriteLine("You did not select a valid option.");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        private void DisplayMenu(MenuClass menuItem)
        {
            Console.WriteLine($"#{ menuItem.MealNumber}: The {menuItem.MealName}\n" +
                $"  Description: {menuItem.MealDesc}\n" +
                $"  Price: ${menuItem.MealPrice}");
            Console.WriteLine();
        }
        private void DisplayIngredients(MenuClass menuItem, int mealNumber)
        {
            _menuRepository.GetListOfIngredientsByItemNumber(menuItem.MealNumber);
            Console.WriteLine("Ingredients: ");
            foreach (string ingredient in menuItem.MealIngredients)
            {
                Console.WriteLine($"      {ingredient}");
            }
        }
        //Seed Data
        private void SeedContent()
        {//First item
            List<string> numOneIng = new List<string>();
            var numberOne = new MenuClass(1, "Steak Au Poivre", "Filet coated with coarsely cracked peppercorns then cooked", 19.50m, numOneIng);
            numOneIng.Add("Filet");
            numOneIng.Add("Peppercorns");
            numOneIng.Add("Heavy Cream");
            numOneIng.Add("Cognac");
            //Second item
            List<string> numTwoIng = new List<string>();
            var numberTwo = new MenuClass(2, "Ceasar Salad", "mmmm parmesan!", 5.95m, numTwoIng);
            numTwoIng.Add("Romaine Lettuce");
            numTwoIng.Add("Creamy Ceasar Dressing"); 
            numTwoIng.Add("Prepared Table side");
            //Third Item
            List<string> numThreeIng = new List<string>();
            var numberThree = new MenuClass(3, "Chocolate cake", "A 7 layer slice of heaven to end your meal or as a main course", 5.95m, numThreeIng);
            numThreeIng.Add("Decadent Chocolate cake");
            numThreeIng.Add("chocolate buttercream filling");
            numThreeIng.Add("chocolate grenache with a dollup of creme fraiche");       
            //Add items to menu
            _menuRepository.AddMenuItem(numberOne);
            _menuRepository.AddMenuItem(numberTwo);
            _menuRepository.AddMenuItem(numberThree);
        }
    }
}
