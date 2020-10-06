using System;
using System.Collections.Generic;
using _03_Badges_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    //Issues to refactor if time
    //Test issue: Leading 0's on badge IDs are not displaying on console.
    //test issue: console hangs when you press y or n to add another door.  Needs to loop
    //Test Issue - when updating the badge the menu should display all information for that badge ID
    //how would I handle a 'superuser' that needed access to all?  SecAdmin needs to input all doors currently
    [TestClass]
    public class BadgeTest
    {
        private BadgeRepository _badgeRepository;
        [TestInitialize]
        public void Arrange()
        {
            _badgeRepository = new BadgeRepository();
        }         
        [TestMethod]
        public void AddBadgeTest()
        {
            var key = 12345;
            var value = new List<string> { "N01", "S01", "N02" };
            _badgeRepository.AddNewBadge(key, value);
            int expected = 1;
            int actual = _badgeRepository.ShowAllBadges().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveAllDoorsTest()
        {
            var key = 12345;
            var value = new List<string> { "N01", "S01", "N02" };
            _badgeRepository.AddNewBadge(key, value);
            _badgeRepository.RemoveAllDoorsFromBadge(key);
            var expected = 0;
            var actual = value.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveDoorFromBadge()
        {
            var key = 12345;
            var value = new List<string> { "N01", "S01", "N02" };
            _badgeRepository.AddNewBadge(key, value);
            _badgeRepository.RemoveDoorFromBadge(12345, "N01");
            var badgeList = _badgeRepository.ShowAllBadges();
            int expected = 2;
            int actual = value.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
