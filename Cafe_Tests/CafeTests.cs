using System;
using System.Collections.Generic;
using Cafe_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    //Naming issue - I failed to name Cafe challenge correctly when I built the project.  Should have started all assemblies with 01_  I tried to go fix it but ran out of time, and found there are way to many steps.  
    [TestClass]
    public class CafeTests
    {
        private MenuRepository _testMenuRepo;
        private MenuClass _numberOne;
        private MenuClass _numberTwo;
        private MenuClass _numberThree;

        [TestInitialize]
        public void TestInit()
        {
            _testMenuRepo = new MenuRepository();
            List<string> numOneIng = new List<string>();
            List<string> numTwoIng = new List<string>();
            List<string> numThreeIng = new List<string>();
            numOneIng.Add("Filet");
            numOneIng.Add("Peppercorns");
            numOneIng.Add("Heavy Cream");
            numOneIng.Add("Cognac");

            _numberOne = new MenuClass(1, "Steak Au Poivre", "Filet coated with coarsely cracked peppercorns then cooked", 19.50m, numOneIng);
            _numberTwo = new MenuClass(2, "Ceasar Salad", "mmmm parmesan!", 5.95m, numTwoIng);
            _numberThree = new MenuClass(3, "Chocolate cake", "A 7 layer slice of heaven to end your meal or as a main course", 5.95m, numThreeIng);

            _testMenuRepo.AddMenuItem(_numberOne);
            _testMenuRepo.AddMenuItem(_numberTwo);
            _testMenuRepo.AddMenuItem(_numberThree);
        }
        [TestMethod]
        public void AddtoMenu_ShouldGetCorrectBoolean()
        {
            List<string> numFourIng = new List<string>();
            var numberFour = new MenuClass(4, "Fried Chicken", "Southern Fried Chicken", 18.95m, numFourIng);
            bool addResult = _testMenuRepo.AddMenuItem(numberFour);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetMealOneInfo_ShouldReturnCorrectInfo()
        {
            MenuClass searchResult = _testMenuRepo.GetMenuItemByNumber(1);
            Assert.AreEqual(_numberOne, searchResult);
        }
        [TestMethod]
        public void PrintAllMenuItems_ShouldPrintNumbersAndTitlesOfAllMenuItems()
        {
            List<MenuClass> results =
            _testMenuRepo.GetAllMenuItems();
            foreach (MenuClass item in results)
            {

                Console.WriteLine($"#{item.MealNumber}:  {item.MealName}");
            }
        }
        [TestMethod]
        public void GetIngredientsByMealNumber_ShouldReturnListOfIngredients()
        {
            List<string> ingredientsList = _testMenuRepo.GetListOfIngredientsByItemNumber(1);
            foreach (string ingredient in ingredientsList)
            {
                Console.WriteLine(ingredient);
            }
        }
        [TestMethod]
        public void DeleteMenuItemByNumber_ShouldDeleteCorrectItem()
        {
            MenuClass searchResult = _testMenuRepo.GetMenuItemByNumber(2);
            _testMenuRepo.DeleteMenuItem(searchResult);
            List<MenuClass> results = _testMenuRepo.GetAllMenuItems();
            foreach (MenuClass item in results)
            {
                Console.WriteLine($"#{item.MealNumber}:  {item.MealName}");
            }
        }
    }
}

