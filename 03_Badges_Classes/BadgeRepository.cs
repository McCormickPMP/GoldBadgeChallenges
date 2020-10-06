using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Classes
{
    public class BadgeRepository
    {
        //Dictionary has key,value
        private Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();
        public void AddNewBadge(int key, List<string> value)
         //handle exceptions for badge ID that has already been used...
        {
            try
            {
                _badgeDirectory.Add(key, value);
            }
            catch
            {
                Console.WriteLine("This badge is already in the system");
            }
        }
        //Create/Show
        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _badgeDirectory;
        }
        //View one badge
        public Badge ViewSuperBadge(int badgeId)
        {
            Badge badge = new Badge(badgeId, _badgeDirectory[badgeId]);
            return badge;
        }
        //Delete All access
        public void RemoveAllDoorsFromBadge(int badgeId)
        {
            _badgeDirectory[badgeId].Clear();
        }
        //Delete one door
        public void RemoveDoorFromBadge(int badgeId, string doorNumber)
        {
            _badgeDirectory[badgeId].Remove(doorNumber);
        }
    }
}
